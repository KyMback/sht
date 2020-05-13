using System.Threading.Tasks;

namespace SHT.Infrastructure.BackgroundProcess.Interfaces
{
    /// <summary>
    /// Represents a job which is set to automatically repeat for the specified schedule.
    /// </summary>
    public interface IRecurringJob
    {
        /// <summary>
        /// Executes the job when the specified time interval occurs.
        /// </summary>
        /// <returns>A task that represents the completion of the write operation.</returns>
        Task Execute();
    }
}
