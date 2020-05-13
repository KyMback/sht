using System;

namespace SHT.BackgroundProcess.Jobs
{
    /// <summary>
    /// Decorates a job as an implementation of the specified job name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal class JobAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the job.</param>
        public JobAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the job's name.
        /// </summary>
        public string Name { get; }
    }
}
