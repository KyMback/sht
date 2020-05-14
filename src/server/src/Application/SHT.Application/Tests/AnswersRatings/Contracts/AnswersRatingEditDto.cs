using System;
using System.Collections.Generic;
using SHT.Application.Common;

namespace SHT.Application.Tests.AnswersRatings.Contracts
{
    [ApiDataContract]
    public class AnswersRatingEditDto
    {
        public Guid Id { get; set; }

        public IReadOnlyCollection<AnswersRatingItemEditDto> RatingItems { get; set; }
    }
}