using System.Linq;
using MediatR;
using SHT.Application.TestVariants.Contracts;

namespace SHT.Application.TestVariants.GetAll
{
    public class GetAllTestVariantsRequest : IRequest<IQueryable<TestVariantDto>>
    {
    }
}