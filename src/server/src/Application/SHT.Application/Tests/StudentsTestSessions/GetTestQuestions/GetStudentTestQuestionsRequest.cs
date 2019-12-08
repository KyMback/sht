using System;
using System.Collections.Generic;
using MediatR;

namespace SHT.Application.Tests.StudentsTestSessions.GetTestQuestions
{
    public class GetStudentTestQuestionsRequest : IRequest<IReadOnlyCollection<StudentTestQuestionListItemDto>>
    {
        public GetStudentTestQuestionsRequest(Guid studentSessionId)
        {
            StudentSessionId = studentSessionId;
        }

        public Guid StudentSessionId { get; set; }
    }
}