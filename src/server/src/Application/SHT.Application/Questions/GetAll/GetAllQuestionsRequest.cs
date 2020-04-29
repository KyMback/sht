using System.Linq;
using MediatR;
using SHT.Application.Questions.Contracts;

namespace SHT.Application.Questions.GetAll
{
    public class GetAllQuestionsRequest : IRequest<IQueryable<QuestionDto>>
    {
    }
}