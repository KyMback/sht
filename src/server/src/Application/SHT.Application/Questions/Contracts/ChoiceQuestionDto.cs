using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using SHT.Common.Utils;
using SHT.Domain.Models.Questions.WithChoice;

namespace SHT.Application.Questions.Contracts
{
    public class ChoiceQuestionDto
    {
        public static readonly Expression<Func<ChoiceQuestionTemplate, ChoiceQuestionDto>> Selector =
            ExpressionUtils.Expand<ChoiceQuestionTemplate, ChoiceQuestionDto>(question =>
                new ChoiceQuestionDto
                {
                    QuestionText = question.QuestionText,
                    Options = question.Options
                        .Select(e => ChoiceQuestionOptionDto.Selector.Invoke(e))
                        .ToList(),
                });

        public string QuestionText { get; set; }

        public IList<ChoiceQuestionOptionDto> Options { get; set; }
    }
}