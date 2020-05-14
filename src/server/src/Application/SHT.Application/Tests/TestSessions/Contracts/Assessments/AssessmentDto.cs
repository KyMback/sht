using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using SHT.Common.Utils;
using SHT.Domain.Models.TestSessions.Assessments;

namespace SHT.Application.Tests.TestSessions.Contracts.Assessments
{
    public class AssessmentDto
    {
        public static readonly Expression<Func<Assessment, AssessmentDto>> Selector =
            ExpressionUtils.Expand<Assessment, AssessmentDto>(assessment =>
                new AssessmentDto
                {
                    Id = assessment.Id,
                    TestSessionId = assessment.TestSessionId,
                    AssessmentQuestions = assessment.AnswersAssessmentQuestions
                        .Select(e => AnswersAssessmentQuestionDto.Selector.Invoke(e))
                        .ToArray(),
                });

        public Guid Id { get; set; }

        public Guid TestSessionId { get; set; }

        public IReadOnlyCollection<AnswersAssessmentQuestionDto> AssessmentQuestions { get; set; }
    }
}