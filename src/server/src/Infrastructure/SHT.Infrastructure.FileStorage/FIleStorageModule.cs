using Autofac;
using SHT.Infrastructure.Common.Extensions;
using SHT.Infrastructure.FileStorage.StorageStrategies;
using SHT.Infrastructure.FileStorage.StorageStrategies.FileSystem;

namespace SHT.Infrastructure.FileStorage
{
    public class FIleStorageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .AddScopedAsImplementedInterfaces<FilesStorage>();

            builder
                .RegisterType<FilesSystemStorageStrategy>()
                .Keyed<IFilesStorageStrategy>(FileStorageType.FileSystem)
                .InstancePerLifetimeScope();
        }
    }
}