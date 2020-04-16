using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Language;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using HotChocolate.Types.Selections;
using HotChocolate.Utilities;
using SHT.Api.Web.GraphQl.Queries.Paging;

namespace SHT.Api.Web.GraphQl.Queries.Selection
{
    /// <summary>
    /// Simple custom overriding of <see cref="SelectionVisitor"/> to support selection of offset based pagination
    /// HotChocolate.Types.Selections v10.4.0
    /// </summary>
    public class CustomSelectionVisitor : SelectionVisitor
    {
        public CustomSelectionVisitor(IResolverContext context, ITypeConversion converter)
            : base(context, converter)
        {
        }

        public new void Accept(ObjectField field)
        {
            IOutputType type = field.Type;
            SelectionSetNode selectionSet = Context.FieldSelection.SelectionSet;
            (type, selectionSet) = UnwrapOffsetBasedPaging(type, selectionSet);
            IType elementType = type.IsListType() ? type.ElementType() : type;
            Closures.Push(new SelectionClosure(elementType.ToClrType(), "e"));
            VisitSelections(type, selectionSet);
        }

        protected override bool VisitSelections(IOutputType outputType, SelectionSetNode selectionSet)
        {
            (outputType, selectionSet) = UnwrapOffsetBasedPaging(outputType, selectionSet);
            if (outputType.NamedType() is ObjectType type)
            {
                foreach (IFieldSelection selection in CollectExtendedFields(type, selectionSet))
                {
                    if (EnterSelection(selection))
                    {
                        LeaveSelection(selection);
                    }
                }
            }
            else
            {
                throw new QueryException(
                    ErrorBuilder.New()
                        .SetMessage(
                            string.Format(
                                CultureInfo.InvariantCulture,
                                "UseSelection is in a invalid state. Type {0} is illegal!",
                                outputType.NamedType().Name))
                        .Build());
            }

            return true;
        }

        protected override bool EnterList(IFieldSelection selection)
        {
            if (selection.Field.Member is PropertyInfo)
            {
                (IOutputType type, SelectionSetNode selectionSet) =
                    UnwrapOffsetBasedPaging(selection.Field.Type, selection.Selection.SelectionSet);

                Type clrType = type.IsListType() ?
                    type.ElementType().ToClrType() :
                    type.ToClrType();

                Closures.Push(new SelectionClosure(clrType, "e" + Closures.Count));

                return VisitSelections(type, selectionSet);
            }

            return false;
        }

        private (IOutputType, SelectionSetNode) UnwrapOffsetBasedPaging(
            IOutputType outputType,
            SelectionSetNode selectionSet)
        {
            if (outputType is ISearchResult)
            {
                if (TryUnwrapOffsetBasedPaging(
                    outputType,
                    selectionSet,
                    out (IOutputType, SelectionSetNode) result))
                {
                    return result;
                }
            }

            return (outputType, selectionSet);
        }

        private bool TryUnwrapOffsetBasedPaging(
            IOutputType outputType,
            SelectionSetNode selectionSet,
            out (IOutputType, SelectionSetNode) result)
        {
            result = (null, null);

            if (outputType.NamedType() is ObjectType type)
            {
                foreach (IFieldSelection selection in Context.CollectFields(type, selectionSet))
                {
                    IFieldSelection currentSelection = GetOffsetBasedPagingFieldOrDefault(selection);

                    if (currentSelection != null)
                    {
                        result = MergeSelection(result.Item2, currentSelection);
                    }
                }
            }

            return result.Item2 != null;
        }

        private IFieldSelection GetOffsetBasedPagingFieldOrDefault(IFieldSelection selection)
        {
            if (selection.Field.Name == "items")
            {
                return selection;
            }

            return null;
        }

        private (IOutputType, SelectionSetNode) MergeSelection(
            SelectionSetNode selectionSet,
            IFieldSelection selection)
        {
            if (selectionSet == null)
            {
                selectionSet = selection.Selection.SelectionSet;
            }
            else
            {
                selectionSet = selectionSet.WithSelections(
                    selectionSet.Selections.Concat(
                            selection.Selection.SelectionSet.Selections)
                        .ToList());
            }

            return (selection.Field.Type, selectionSet);
        }
    }
}