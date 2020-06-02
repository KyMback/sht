namespace SHT.Domain.Questions.Import.Contracts
{
    internal class ChoiceQuestionTemplateOptionImportDto
    {
        public string QuestionTemplateId { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }
    }
}