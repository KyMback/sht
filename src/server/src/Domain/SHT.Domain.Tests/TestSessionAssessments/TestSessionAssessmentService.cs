using System.Linq;
using System.Threading.Tasks;
using SHT.Domain.Models.TestSessions.Assessments;
using SHT.Domain.Services.Student.Questions;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Domain.Services.TestSessionAssessments
{
    internal class TestSessionAssessmentService : ITestSessionAssessmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestSessionAssessmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAssessmentQuestions(Assessment assessment)
        {
            var questions = assessment.AnswersAssessmentQuestions.ToArray();

            foreach (var answersAssessmentQuestion in questions)
            {
                var questionsIds = answersAssessmentQuestion.Questions
                    .Select(e => e.TestSessionVariantQuestionId)
                    .ToArray();
                var queryParams = new StudentQuestionAnswerQueryParameters()
                {
                    TestSessionVariantQuestionIds = questionsIds,
                    IsAnswered = true,
                };
                var answers = await _unitOfWork.GetAll(queryParams, answer => new
                {
                    answer.Id,
                    answer.Question.StudentTestSession.StudentId,
                });
                answersAssessmentQuestion.AnswersRatings = answers.Select(e => new AnswersRating
                {
                    StudentId = e.StudentId,
                    // TODO: currently we add all answers (except current student answer) for rating
                    AnswersRatingItems = answers.Where(d => d.StudentId != e.StudentId).Select(a => new AnswersRatingItem
                    {
                        StudentQuestionAnswerId = a.Id,
                    }).ToList(),
                }).ToList();
            }

            await _unitOfWork.UpdateRange(questions);
            await _unitOfWork.Commit();
        }

        public Task EvaluateAnswers(Assessment assessment)
        {
            throw new System.NotImplementedException();
        }
    }
}