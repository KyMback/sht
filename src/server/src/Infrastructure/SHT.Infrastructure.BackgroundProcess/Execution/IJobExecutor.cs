using System.Threading.Tasks;
using SHT.Infrastructure.Common.ExecutionContext;

namespace SHT.Infrastructure.BackgroundProcess.Execution
{
    /// <summary>
    ///     Provides an interface to execute the background job.
    /// </summary>
    public interface IJobExecutor
    {
        /// <summary>
        /// Executes the job without context.
        /// </summary>
        /// <typeparam name="TParam">The job parameter type.</typeparam>
        /// <param name="name">The job name to be executed.</param>
        /// <param name="param">Data which should be passed in job.</param>
        /// <returns>Task.</returns>
        Task Execute<TParam>(string name, TParam param);

        /// <summary>
        /// Executes the job within the specified <paramref name="context"/>.
        /// </summary>
        /// <typeparam name="TParam">The job parameter type.</typeparam>
        /// <param name="name">The job name to be executed.</param>
        /// <param name="param">Data which should be passed in the job.</param>
        /// <param name="context">The execution context of the job.</param>
        /// <returns>Task.</returns>
        Task Execute<TParam>(string name, TParam param, IExecutionContext context);
    }
}
