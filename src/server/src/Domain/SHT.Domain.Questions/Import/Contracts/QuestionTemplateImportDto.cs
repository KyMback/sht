using SHT.Domain.Models.Tests;

namespace SHT.Domain.Questions.Import.Contracts
{
    internal class QuestionTemplateImportDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string QuestionText { get; set; }

        public QuestionType Type { get; set; }

        public bool IsShareable { get; set; }
    }
}