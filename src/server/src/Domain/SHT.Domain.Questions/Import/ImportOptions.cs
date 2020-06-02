using System;
using System.IO;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace SHT.Domain.Questions.Import
{
    public class ImportOptions
    {
        [NotNull]
        public Func<Task<Stream>> QuestionTemplatesStreamAccessor { get; set; }

        [CanBeNull]
        public Func<Task<Stream>> ChoiceQuestionsOptionsStreamAccessor { get; set; }
    }
}