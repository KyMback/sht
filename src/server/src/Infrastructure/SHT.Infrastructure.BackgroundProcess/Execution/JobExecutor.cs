using System.Threading.Tasks;
using Autofac;
using SHT.Infrastructure.BackgroundProcess.Interfaces;
using SHT.Infrastructure.Common.ExecutionContext;

namespace SHT.Infrastructure.BackgroundProcess.Execution
{
    /// <inheritdoc />
    public class JobExecutor : IJobExecutor
    {
        private readonly ILifetimeScope _lifetimeScope;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobExecutor"/> class.
        /// </summary>
        /// <param name="lifetimeScope">The <see cref="ILifetimeScope"/>.</param>
        public JobExecutor(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        /// <inheritdoc />
        public Task Execute<TParam>(string name, TParam param)
        {
            return ResolveJob<TParam>(name).Execute(param);
        }

        public Task Execute<TParam>(string name, TParam param, IExecutionContext context)
        {
            return ResolveJob<TParam>(name).Execute(param, context);
        }

        private IJob<TParam> ResolveJob<TParam>(string name)
        {
            return _lifetimeScope.ResolveKeyed<IJob<TParam>>(name);
        }
    }
}
