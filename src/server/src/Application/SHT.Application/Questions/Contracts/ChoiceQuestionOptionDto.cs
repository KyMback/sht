using System;
using System.Linq.Expressions;
using SHT.Application.Common;
using SHT.Common.Utils;
using SHT.Domain.Models.Questions.WithChoice;

namespace SHT.Application.Questions.Contracts
{
    [ApiDataContract]
    public class ChoiceQuestionOptionDto
    {
        public static readonly Expression<Func<ChoiceQuestionTemplateOption, ChoiceQuestionOptionDto>> Selector =
            ExpressionUtils.Expand<ChoiceQuestionTemplateOption, ChoiceQuestionOptionDto>(question =>
                new ChoiceQuestionOptionDto
                {
                    Id = question.Id,
                    Text = question.Text,
                    IsCorrect = question.IsCorrect,
                });

        public Guid Id { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set;  }
    }
}