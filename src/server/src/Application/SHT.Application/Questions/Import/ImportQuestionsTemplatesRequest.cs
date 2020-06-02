using System;
using MediatR;

namespace SHT.Application.Questions.Import
{
    public class ImportQuestionsTemplatesRequest : IRequest
    {
        public ImportQuestionsTemplatesRequest(Guid questionTemplatesFileId, Guid? choiceQuestionsOptionsFileId)
        {
            QuestionTemplatesFileId = questionTemplatesFileId;
            ChoiceQuestionsOptionsFileId = choiceQuestionsOptionsFileId;
        }

        public Guid QuestionTemplatesFileId { get; set; }

        public Guid? ChoiceQuestionsOptionsFileId { get; set; }
    }
}