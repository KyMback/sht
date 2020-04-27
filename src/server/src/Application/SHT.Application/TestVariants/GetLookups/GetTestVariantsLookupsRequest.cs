using System.Linq;
using MediatR;
using SHT.Application.Common;

namespace SHT.Application.TestVariants.GetLookups
{
    public class GetTestVariantsLookupsRequest : IRequest<IQueryable<Lookup>>
    {
    }
}