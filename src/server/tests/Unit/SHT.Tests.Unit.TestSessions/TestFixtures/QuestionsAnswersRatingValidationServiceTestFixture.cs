using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Models.TestSessions.Assessments;
using SHT.Domain.Services.TestSessionAssessments;
using SHT.Tests.Unit.Infrastructure.Attributes;
using Xunit;

namespace SHT.Tests.Unit.TestSessions.TestFixtures
{
    public class QuestionsAnswersRatingValidationServiceTestFixture
    {
        [Theory]
        [InlineAutoMoqData(TestSessionState.Ended)]
        [InlineAutoMoqData(TestSessionState.Started)]
        [InlineAutoMoqData(TestSessionState.Pending)]
        internal async Task ValidateOnRate_TestSessionNotInAssessmentPhase_ThrowsException(
            string testSessionState,
            QuestionsAnswersRatingValidationService questionsAnswersRatingValidationService)
        {
            // Arrange
            var rating = new AnswersRating
            {
                AnswersAssessmentQuestion = new AnswersAssessmentQuestion
                {
                    Assessment = new Assessment
                    {
                        TestSession = new TestSession
                        {
                            State = testSessionState,
                        },
                    },
                },
            };
            var ratingItems = new List<QuestionsAnswersRatingItemData>();

            // Act
            Func<Task> action = () => questionsAnswersRatingValidationService.ValidateOnRate(rating, ratingItems);

            // Assert
            await action.Should().ThrowExactlyAsync<InvalidOperationException>();
        }

        [Theory]
        [AutoMoqData]
        internal async Task ValidateOnRate_TestSessionInAssessmentPhase_Success(
            QuestionsAnswersRatingValidationService questionsAnswersRatingValidationService)
        {
            // Arrange
            var rating = new AnswersRating
            {
                AnswersAssessmentQuestion = new AnswersAssessmentQuestion
                {
                    Assessment = new Assessment
                    {
                        TestSession = new TestSession
                        {
                            State = TestSessionState.Assessment,
                        },
                    },
                },
            };
            var ratingItems = new List<QuestionsAnswersRatingItemData>();

            // Act
            Func<Task> action = () => questionsAnswersRatingValidationService.ValidateOnRate(rating, ratingItems);

            // Assert
            await action.Should().NotThrowAsync<InvalidOperationException>();
        }

        [Theory]
        [AutoMoqData]
        internal async Task ValidateOnRate_ItemsWithDuplicatedRatings_ThrowsException(
            QuestionsAnswersRatingValidationService questionsAnswersRatingValidationService)
        {
            // Arrange
            var rating = new AnswersRating
            {
                AnswersAssessmentQuestion = new AnswersAssessmentQuestion
                {
                    Assessment = new Assessment
                    {
                        TestSession = new TestSession
                        {
                            State = TestSessionState.Assessment,
                        },
                    },
                },
            };
            var ratingItems = new List<QuestionsAnswersRatingItemData>
            {
                new QuestionsAnswersRatingItemData
                {
                    Rating = 1,
                },
                new QuestionsAnswersRatingItemData
                {
                    Rating = 1,
                },
            };

            // Act
            Func<Task> action = () => questionsAnswersRatingValidationService.ValidateOnRate(rating, ratingItems);

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>();
        }

        [Theory]
        [AutoMoqData]
        internal async Task ValidateOnRate_ItemsWithIncorrectRatings_ThrowsException(
            QuestionsAnswersRatingValidationService questionsAnswersRatingValidationService)
        {
            // Arrange
            var rating = new AnswersRating
            {
                AnswersAssessmentQuestion = new AnswersAssessmentQuestion
                {
                    Assessment = new Assessment
                    {
                        TestSession = new TestSession
                        {
                            State = TestSessionState.Assessment,
                        },
                    },
                },
            };
            var ratingItems = new List<QuestionsAnswersRatingItemData>
            {
                new QuestionsAnswersRatingItemData
                {
                    Rating = -1,
                },
                new QuestionsAnswersRatingItemData
                {
                    Rating = -2,
                },
            };

            // Act
            Func<Task> action = () => questionsAnswersRatingValidationService.ValidateOnRate(rating, ratingItems);

            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>();
        }
    }
}