using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoreLinq.Extensions;
using SHT.Domain.Models.Tests;
using SHT.Domain.Questions.Templates;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Tests.Variants
{
    internal class TestVariantService : ITestVariantService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestVariantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<TestVariant> Create(string name)
        {
            return _unitOfWork.Add(new TestVariant
            {
                Name = name,
            });
        }

        public async Task LinkQuestions(
            Guid variantId,
            IReadOnlyCollection<TestVariantLinkQuestionData> linkQuestionData)
        {
            var queryParameters = new TestVariantQuestionQueryParameters
            {
                TestVariantId = variantId,
                IsReadOnly = false,
            };
            IReadOnlyCollection<TestVariantQuestion> existing = await _unitOfWork.GetAll(queryParameters);

            var join = existing.FullJoin(
                linkQuestionData,
                question => question.Id,
                data => data.Id,
                question => (question, null),
                data => (null, data),
                (question, data) => (question, data)).ToArray();

            foreach ((TestVariantQuestion question, TestVariantLinkQuestionData data) in join)
            {
                if (data == null)
                {
                    await _unitOfWork.Delete(question);
                    continue;
                }

                if (question == null)
                {
                    var originalQuestionData = await GetQuestionData(data.OriginalQuestionId.Value);

                    await _unitOfWork.Add(new TestVariantQuestion
                    {
                        Number = data.Number,
                        Text = originalQuestionData.Text,
                        Type = originalQuestionData.Type,
                        TestVariantId = variantId,
                    });
                }
                else
                {
                    question.Number = data.Number;
                    var originalQuestionData = await GetQuestionData(data.OriginalQuestionId.Value);
                    question.Text = originalQuestionData.Text;
                    question.Type = originalQuestionData.Type;
                    await _unitOfWork.Update(question);
                }
            }
        }

        private Task<QuestionData> GetQuestionData(Guid questionId)
        {
            var questionQueryParameters = new QuestionTemplateQueryParameters
            {
                Id = questionId,
            };

            return _unitOfWork.GetSingle(questionQueryParameters, q => new QuestionData
            {
                Text = q.Text,
                Type = q.Type,
            });
        }

        private class QuestionData
        {
            public string Text { get; set; }

            public QuestionType Type { get; set; }
        }
    }
}