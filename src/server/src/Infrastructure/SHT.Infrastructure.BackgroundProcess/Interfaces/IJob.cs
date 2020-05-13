using System.Threading.Tasks;
using SHT.Infrastructure.Common.ExecutionContext;

namespace SHT.Infrastructure.BackgroundProcess.Interfaces
{
    /// <summary>
    /// Interface for parameterized jobs.
    /// </summary>
    /// <typeparam name="T">The parameter type.</typeparam>
    public interface IJob<in T>
    {
        /// <summary>
        /// Executes the job with the specified parameter.
        /// </summary>
        /// <param name="param">The job parameter.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Execute(T param);

        /// <summary>
        /// Executes the job with the specified parameter and execution context.
        /// </summary>
        /// <param name="param">The job parameter.</param>
        /// <param name="context">The execution context of the job.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task Execute(T param, IExecutionContext context);
    }
}
