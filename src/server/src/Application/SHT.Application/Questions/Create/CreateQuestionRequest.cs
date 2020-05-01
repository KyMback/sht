using MediatR;
using SHT.Application.Common;
using SHT.Application.Questions.Contracts;

namespace SHT.Application.Questions.Create
{
    public class CreateQuestionRequest : IRequest<CreatedEntityResponse>
    {
        public CreateQuestionRequest(QuestionEditDetailsDto data)
        {
            Data = data;
        }

        public QuestionEditDetailsDto Data { get; set; }
    }
}