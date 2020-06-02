using System.Threading.Tasks;

namespace SHT.Domain.Questions.Import
{
    public interface IQuestionTemplateImportService
    {
        Task ImportCsv(ImportOptions options);
    }
}