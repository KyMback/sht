using System;
using System.Linq.Expressions;
using SHT.Application.Tests.TestSessions.Contracts;
using SHT.Common.Utils;
using SHT.Domain.Models.Tests;

namespace SHT.Application.Questions.Contracts
{
    public class QuestionDto
    {
        public static readonly Expression<Func<QuestionTemplate, QuestionDto>> Selector =
            ExpressionUtils.Expand<QuestionTemplate, QuestionDto>(session =>
                new QuestionDto
                {
                    Id = session.Id,
                    Name = session.Name,
                    Type = session.Type,
                    Text = session.Text,
                    CreatedById = session.CreatedById,
                });

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public QuestionType Type { get; set; }

        public Guid CreatedById { get; set; }
    }
}