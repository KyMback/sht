namespace SHT.Domain.Services.Student.Questions
{
    public class QuestionGenericAnswer
    {
        public QuestionFreeTextAnswer FreeTextAnswer { get; set; }

        public ChoiceQuestionAnswer ChoiceQuestionAnswer { get; set; }
    }
}