using System;
using SHT.Domain.Common.Core;
using SHT.Domain.Models.Tests.Students;

namespace SHT.Domain.Services.Tests.Student.Questions
{
    public class StudentQuestionQueryParameters : BaseQueryParameters<StudentQuestion>
    {
        public Guid? Id { get; set; }

        public Guid? StudentTestSessionId { get; set; }

        public Guid? StudentId { get; set; }

        public bool OrderAscByNumber { get; set; }

        protected override void AddFilters()
        {
            FilterIfHasValue(
                StudentTestSessionId,
                question => question.StudentTestSessionId == StudentTestSessionId.Value);
            FilterIfHasValue(StudentId, question => question.StudentTestSession.StudentId == StudentId.Value);
            FilterIfHasValue(Id, question => question.Id == Id.Value);
        }

        protected override void AddSorting()
        {
            SortAscIf(OrderAscByNumber, question => question.Number);
        }
    }
}