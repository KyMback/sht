using System.Collections.Generic;
using MediatR;
using SHT.Application.Common;

namespace SHT.Application.Tests.Variants.GetLookups
{
    public class GetVariantsLookupsRequest : IRequest<IReadOnlyCollection<Lookup>>
    {
    }
}