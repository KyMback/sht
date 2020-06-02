using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using MediatR;
using SHT.Domain.Common.Files;
using SHT.Domain.Questions.Import;
using SHT.Infrastructure.Common.ExecutionContext;
using SHT.Infrastructure.DataAccess.Abstractions;

namespace SHT.Application.Questions.Import
{
    [UsedImplicitly]
    internal class ImportQuestionsTemplatesHandler : IRequestHandler<ImportQuestionsTemplatesRequest>
    {
        private readonly IQuestionTemplateImportService _questionTemplateImportService;
        private readonly IExecutionContextService _executionContextService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public ImportQuestionsTemplatesHandler(
            IQuestionTemplateImportService questionTemplateImportService,
            IExecutionContextService executionContextService,
            IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            _questionTemplateImportService = questionTemplateImportService;
            _executionContextService = executionContextService;
            _unitOfWork = unitOfWork;
            _fileService = fileService;
        }

        public async Task<Unit> Handle(ImportQuestionsTemplatesRequest request, CancellationToken cancellationToken)
        {
            await _questionTemplateImportService.ImportCsv(new ImportOptions
            {
                QuestionTemplatesStreamAccessor = await GetFileStreamAccessor(request.QuestionTemplatesFileId),
                ChoiceQuestionsOptionsStreamAccessor = request.ChoiceQuestionsOptionsFileId.HasValue
                    ? await GetFileStreamAccessor(request.ChoiceQuestionsOptionsFileId.Value)
                    : null,
            });

            await _unitOfWork.Commit();

            return default;
        }

        private Task<Func<Task<Stream>>> GetFileStreamAccessor(Guid fileId)
        {
            var queryParameters = new FileQueryParameters
            {
                CreatedById = _executionContextService.GetCurrentUserId(),
                Id = fileId,
            };
            return _fileService.GetFileStreamAccessor(queryParameters);
        }
    }
}