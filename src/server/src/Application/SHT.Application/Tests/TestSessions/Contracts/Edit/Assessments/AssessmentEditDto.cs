using System;
using System.Collections.Generic;
using SHT.Application.Common;

namespace SHT.Application.Tests.TestSessions.Contracts.Edit.Assessments
{
    [ApiDataContract]
    public class AssessmentEditDto
    {
        public Guid? Id { get; set; }

        public IReadOnlyCollection<AnswersAssessmentQuestionEditDto> AssessmentQuestions { get; set; }
    }
}