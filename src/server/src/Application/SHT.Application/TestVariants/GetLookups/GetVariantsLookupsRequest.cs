using System.Collections.Generic;
using MediatR;
using SHT.Application.Common;

namespace SHT.Application.TestVariants.GetLookups
{
    public class GetVariantsLookupsRequest : IRequest<IReadOnlyCollection<Lookup>>
    {
    }
}