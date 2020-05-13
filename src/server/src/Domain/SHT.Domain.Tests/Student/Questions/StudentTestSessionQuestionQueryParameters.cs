using System;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.TestSessions.Students;

namespace SHT.Domain.Services.Student.Questions
{
    public class StudentTestSessionQuestionQueryParameters : BaseQueryParameters<StudentTestSessionQuestion>
    {
        public Guid? StudentTestSessionId { get; set; }

        public Guid? StudentId { get; set; }

        public Guid? Id { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(Id, question => question.Id == Id.Value);
            FilterIfHasValue(StudentId, question => question.StudentTestSession.StudentId == StudentId.Value);
            FilterIfHasValue(StudentTestSessionId, question => question.StudentTestSessionId == StudentTestSessionId.Value);
        }
    }
}