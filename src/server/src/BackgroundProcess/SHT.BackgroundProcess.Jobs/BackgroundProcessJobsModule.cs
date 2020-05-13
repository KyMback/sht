using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Hangfire;
using MoreLinq.Extensions;
using SHT.Common.Utils;
using SHT.Infrastructure.BackgroundProcess.Interfaces;

namespace SHT.BackgroundProcess.Jobs
{
    public class BackgroundProcessJobsModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterJobs(builder);
            RegisterRecurringJobs(builder);

            base.Load(builder);
        }

        private void RegisterRecurringJobs(ContainerBuilder builder)
        {
            var jobs = ThisAssembly.GetTypes()
                .Where(type => type.IsClass && !type.IsAbstract && typeof(BaseRecurringJob).IsAssignableFrom(type));

            jobs.ForEach(job => builder.RegisterType(job).AsSelf()
                .InstancePerBackgroundJob());
        }

        private void RegisterJobs(ContainerBuilder builder)
        {
            foreach (Type jobType in GetParametrizedJobTypes())
            {
                string key = jobType.GetCustomAttribute<JobAttribute>().Name;

                builder.RegisterType(jobType)
                    .Keyed(key, jobType.GetInterfaces().Single(i => TypeUtils.IsClosedTypeOf(i, typeof(IJob<>))))
                    .InstancePerBackgroundJob();
            }
        }

        private Type[] GetParametrizedJobTypes()
        {
            return ThisAssembly.GetTypes().Where(
                    type => !type.IsGenericType &&
                            !type.IsAbstract &&
                            TypeUtils.IsFinalClassImplementationOfOpenGenericInterface(type, typeof(IJob<>)))
                .ToArray();
        }
    }
}
