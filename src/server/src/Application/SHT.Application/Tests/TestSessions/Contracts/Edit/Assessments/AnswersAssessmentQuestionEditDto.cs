using System;
using System.Collections.Generic;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Contracts.Edit.Assessments
{
    [ApiDataContract]
    public class AnswersAssessmentQuestionEditDto
    {
        public Guid? Id { get; set; }

        public string QuestionText { get; set; }

        public IReadOnlyCollection<Guid> Questions { get; set; }
    }
}