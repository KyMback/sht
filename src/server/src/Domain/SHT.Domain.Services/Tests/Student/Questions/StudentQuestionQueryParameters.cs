using System;
using SHT.Domain.Models.Tests.Students;
using SHT.Domain.Services.Common;

namespace SHT.Domain.Services.Tests.Student.Questions
{
    public class StudentQuestionQueryParameters : BaseQueryParameters<StudentQuestion>
    {
        public Guid? StudentTestSessionId { get; set; }

        public Guid? StudentId { get; set; }

        public bool OrderAscByNumber { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(
                StudentTestSessionId,
                question => question.StudentTestSessionId == StudentTestSessionId.Value);
            FilterIfHasValue(StudentId, question => question.StudentTestSession.StudentId == StudentId.Value);
        }

        protected override void AddSorting()
        {
            SortAscIf(OrderAscByNumber, question => question.Number);
        }
    }
}