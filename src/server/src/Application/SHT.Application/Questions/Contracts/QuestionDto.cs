using System;
using System.Linq.Expressions;
using LinqKit;
using SHT.Application.Users.Instructors.Contracts;
using SHT.Common.Utils;
using SHT.Domain.Models.Questions;
using SHT.Domain.Models.Tests;

namespace SHT.Application.Questions.Contracts
{
    public class QuestionDto
    {
        public static readonly Expression<Func<QuestionTemplate, QuestionDto>> Selector =
            ExpressionUtils.Expand<QuestionTemplate, QuestionDto>(question =>
                new QuestionDto
                {
                    Id = question.Id,
                    Name = question.Name,
                    Type = question.Type,
                    FreeTextQuestion = question.FreeTextQuestionTemplate != null
                        ? FreeTextQuestionDto.Selector.Invoke(question.FreeTextQuestionTemplate)
                        : null,
                    ChoiceQuestion = question.ChoiceQuestionTemplate != null
                        ? ChoiceQuestionDto.Selector.Invoke(question.ChoiceQuestionTemplate)
                        : null,
                    CreatedBy = InstructorDto.Selector.Invoke(question.CreatedBy),
                });

        public Guid Id { get; set; }

        public string Name { get; set; }

        public FreeTextQuestionDto FreeTextQuestion { get; set; }

        public ChoiceQuestionDto ChoiceQuestion { get; set; }

        public QuestionType Type { get; set; }

        public InstructorDto CreatedBy { get; set; }
    }
}