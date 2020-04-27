using System.Linq;
using MediatR;
using SHT.Application.Tests.StudentQuestions.Contracts;

namespace SHT.Application.Tests.StudentQuestions.GetAll
{
    public class GetAllStudentTestQuestionsRequest : IRequest<IQueryable<StudentTestQuestionDto>>
    {
    }
}