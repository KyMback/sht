using System;
using MediatR;

namespace SHT.Application.Tests.StudentQuestions.Get
{
    public class GetStudentQuestionRequest : IRequest<StudentQuestionDto>
    {
        public GetStudentQuestionRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}