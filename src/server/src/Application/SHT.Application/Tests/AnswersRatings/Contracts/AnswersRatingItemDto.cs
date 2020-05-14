using System;
using System.Linq.Expressions;
using LinqKit;
using SHT.Application.Tests.StudentQuestions.Contracts;
using SHT.Common.Utils;
using SHT.Domain.Models.TestSessions.Assessments;

namespace SHT.Application.Tests.AnswersRatings.Contracts
{
    public class AnswersRatingItemDto
    {
        public static readonly Expression<Func<AnswersRatingItem, AnswersRatingItemDto>> Selector =
            ExpressionUtils.Expand<AnswersRatingItem, AnswersRatingItemDto>(item =>
                new AnswersRatingItemDto
                {
                    Id = item.Id,
                    Rating = item.Rating,
                    Answer = StudentQuestionAnswerDto.Selector.Invoke(item.Answer),
                });

        public Guid Id { get; set; }

        public int? Rating { get; set; }

        public StudentQuestionAnswerDto Answer { get; set; }
    }
}