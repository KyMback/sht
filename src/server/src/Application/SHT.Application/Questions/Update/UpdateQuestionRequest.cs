using System;
using MediatR;
using SHT.Application.Questions.Contracts;

namespace SHT.Application.Questions.Update
{
    public class UpdateQuestionRequest : IRequest
    {
        public UpdateQuestionRequest(QuestionEditDetailsDto data, Guid id)
        {
            Data = data;
            Id = id;
        }

        public QuestionEditDetailsDto Data { get; set; }

        public Guid Id { get; set; }
    }
}