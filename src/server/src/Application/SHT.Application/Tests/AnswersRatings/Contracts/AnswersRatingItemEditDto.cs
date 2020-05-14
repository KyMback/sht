using System;
using SHT.Application.Common;

namespace SHT.Application.Tests.AnswersRatings.Contracts
{
    [ApiDataContract]
    public class AnswersRatingItemEditDto
    {
        public Guid Id { get; set; }

        public int? Rating { get; set; }
    }
}