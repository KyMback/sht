using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SHT.Common.Utils;
using SHT.Domain.Common.Exceptions;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Models.TestSessions.Variants;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.Student
{
    internal class StudentTestSessionService : IStudentTestSessionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentTestSessionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Start(StudentTestSession studentTestSession, Guid variantId)
        {
            var queryParams = new TestSessionVariantsQueryParameters
            {
                Id = variantId,
                TestSessionId = studentTestSession.TestSessionId,
                IsReadOnly = false,
            };

            var testVariant = await _unitOfWork.GetSingleOrDefault(queryParams);
            if (testVariant == null)
            {
                throw new CodedException(ErrorCode.InvalidVariantName);
            }

            studentTestSession.TestVariantId = variantId;
            studentTestSession.Questions = GenerateQuestions(testVariant);
            await _unitOfWork.Update(studentTestSession);
        }

        private IList<StudentTestSessionQuestion> GenerateQuestions(TestSessionVariant variant)
        {
            var questions = variant.Questions.Select(e => new StudentTestSessionQuestion
            {
                QuestionId = e.Id,
                Order = e.Order ?? default,
            }).ToList();

            if (variant.IsRandomOrder)
            {
                var orderNumbers = RandomUtils.GenerateRandomSequence(1, questions.Count);
                for (int i = 0; i < orderNumbers.Count; i++)
                {
                    questions[i].Order = orderNumbers[i];
                }
            }

            return questions;
        }
    }
}