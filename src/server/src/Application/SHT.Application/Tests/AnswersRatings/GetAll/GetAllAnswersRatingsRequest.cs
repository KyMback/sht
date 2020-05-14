using System.Linq;
using MediatR;
using SHT.Application.Tests.AnswersRatings.Contracts;

namespace SHT.Application.Tests.AnswersRatings.GetAll
{
    public class GetAllAnswersRatingsRequest : IRequest<IQueryable<AnswersRatingDto>>
    {
    }
}