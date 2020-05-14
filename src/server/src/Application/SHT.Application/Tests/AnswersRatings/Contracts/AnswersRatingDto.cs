using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using SHT.Common.Utils;
using SHT.Domain.Models.TestSessions.Assessments;

namespace SHT.Application.Tests.AnswersRatings.Contracts
{
    public class AnswersRatingDto
    {
        public static readonly Expression<Func<AnswersRating, AnswersRatingDto>> Selector =
            ExpressionUtils.Expand<AnswersRating, AnswersRatingDto>(rating =>
                new AnswersRatingDto
                {
                    Id = rating.Id,
                    QuestionText = rating.AnswersAssessmentQuestion.QuestionText,
                    RatingItems = rating.AnswersRatingItems
                        .Select(e => AnswersRatingItemDto.Selector.Invoke(e))
                        .ToArray(),
                });

        public Guid Id { get; set; }

        public string QuestionText { get; set; }

        public IReadOnlyCollection<AnswersRatingItemDto> RatingItems { get; set; }
    }
}