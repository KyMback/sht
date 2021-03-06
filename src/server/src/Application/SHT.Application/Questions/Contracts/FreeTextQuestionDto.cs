using System;
using System.Linq.Expressions;
using SHT.Application.Common;
using SHT.Common.Utils;
using SHT.Domain.Models.Questions;

namespace SHT.Application.Questions.Contracts
{
    [ApiDataContract]
    public class FreeTextQuestionDto
    {
        public static readonly Expression<Func<FreeTextQuestionTemplate, FreeTextQuestionDto>> Selector =
            ExpressionUtils.Expand<FreeTextQuestionTemplate, FreeTextQuestionDto>(question =>
                new FreeTextQuestionDto
                {
                    Question = question.Question,
                });

        public string Question { get; set; }
    }
}