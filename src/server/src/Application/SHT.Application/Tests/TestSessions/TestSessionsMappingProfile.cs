using System.Linq;
using AutoMapper;
using JetBrains.Annotations;
using MoreLinq.Extensions;
using SHT.Application.Tests.TestSessions.Contracts.Edit;
using SHT.Application.Tests.TestSessions.Contracts.Edit.Assessments;
using SHT.Domain.Models.TestSessions;
using SHT.Domain.Models.TestSessions.Assessments;
using SHT.Domain.Models.TestSessions.Students;
using SHT.Domain.Models.TestSessions.Variants;
using SHT.Domain.Models.TestSessions.Variants.Questions;
using SHT.Infrastructure.Common.Extensions;

namespace SHT.Application.Tests.TestSessions
{
    [UsedImplicitly]
    internal class TestSessionsMappingProfile : Profile
    {
        public TestSessionsMappingProfile()
        {
            CreateMap<TestSessionModificationData, TestSession>()
                .Map(d => d.Name, s => s.Name)
                .Map(d => d.Assessment, s => s.Assessment)
                .Map(d => d.StudentTestDuration, s => s.StudentTestDuration)
                .AfterMap((source, destination, ctx) =>
                {
                    destination.StudentTestSessions = source.StudentsIds.LeftJoin(
                        destination.StudentTestSessions,
                        s => s,
                        d => d.StudentId,
                        s => new StudentTestSession
                        {
                            StudentId = s,
                        },
                        (s, d) => d)
                        .ToList();

                    destination.Variants = source.Variants.LeftJoin(
                        destination.Variants,
                        e => e.Id,
                        e => e.Id,
                        e => ctx.Mapper.Map<TestSessionVariant>(e),
                        (dto, testVariant) => ctx.Mapper.Map(dto, testVariant))
                        .ToList();
                })
                .IgnoreAllOther();

            CreateMap<AssessmentEditDto, Assessment>()
                .AfterMap((source, target, ctx) =>
                {
                    target.AnswersAssessmentQuestions = source.AssessmentQuestions
                        .LeftJoin(
                            target.AnswersAssessmentQuestions,
                            s => s.Id,
                            t => t.Id,
                            s => ctx.Mapper.Map<AnswersAssessmentQuestion>(s),
                            (s, t) => ctx.Mapper.Map(s, t))
                        .ToArray();
                })
                .IgnoreAllOther();

            CreateMap<AnswersAssessmentQuestionEditDto, AnswersAssessmentQuestion>()
                .Map(d => d.QuestionText, s => s.QuestionText)
                .AfterMap((source, target, ctx) =>
                {
                    target.Questions = source.Questions
                        .LeftJoin(
                            target.Questions,
                            s => s,
                            d => d.TestSessionVariantQuestionId,
                            s => new AnswersAssessmentQuestionTestSessionVariantQuestion
                            {
                                TestSessionVariantQuestionId = s,
                            },
                            (s, d) => d)
                        .ToArray();
                })
                .IgnoreAllOther();

            CreateMap<TestSessionVariantModificationData, TestSessionVariant>()
                .Map(d => d.Name, s => s.Name)
                .Map(d => d.IsRandomOrder, s => s.IsRandomOrder)
                .AfterMap((source, destination, ctx) =>
                {
                    destination.Questions = source.Questions.LeftJoin(
                            destination.Questions,
                            s => s.Id,
                            d => d.Id,
                            s => ctx.Mapper.Map<TestSessionVariantQuestion>(s),
                            (s, d) => ctx.Mapper.Map(s, d))
                        .ToList();
                })
                .IgnoreAllOther();

            CreateMap<TestSessionVariantQuestionModificationData, TestSessionVariantQuestion>()
                .Map(d => d.Name, s => s.Name)
                .Map(d => d.Order, s => s.Order)
                .Map(d => d.Type, s => s.Type)
                .Map(d => d.ChoiceQuestion, s => s.ChoiceQuestion)
                .Map(d => d.FreeTextQuestion, s => s.FreeTextQuestion)
                .Map(d => d.SourceQuestionId, s => s.SourceQuestionId)
                .AfterMap((source, destination, ctx) =>
                {
                    destination.Images = source.Images?.LeftJoin(
                        destination.Images,
                        s => s,
                        d => d.FileId,
                        s => new TestSessionVariantQuestionImage
                        {
                            FileId = s,
                        },
                        (optionDto, option) => option).ToList();
                })
                .IgnoreAllOther();

            CreateMap<TestSessionVariantFreeTextQuestionModificationData, TestSessionVariantFreeTextQuestion>()
                .Map(d => d.QuestionText, s => s.QuestionText)
                .IgnoreAllOther();

            CreateMap<TestSessionVariantChoiceQuestionModificationData, TestSessionVariantChoiceQuestion>()
                .Map(d => d.QuestionText, s => s.QuestionText)
                .AfterMap((source, destination, ctx) =>
                {
                    destination.Options = source.Options.LeftJoin(
                            destination.Options,
                            s => s.Id,
                            d => d.Id,
                            s => ctx.Mapper.Map<TestSessionVariantChoiceQuestionOption>(s),
                            (s, d) => ctx.Mapper.Map(s, d))
                        .ToList();
                })
                .IgnoreAllOther();

            CreateMap<TestSessionVariantChoiceQuestionOptionModificationData, TestSessionVariantChoiceQuestionOption>()
                .Map(d => d.Text, s => s.Text)
                .Map(d => d.IsCorrect, s => s.IsCorrect)
                .Map(d => d.IsRequired, s => s.IsCorrect)
                .IgnoreAllOther();
        }
    }
}