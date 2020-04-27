using AutoMapper;

namespace SHT.Infrastructure.Common.AutoMapper
{
    public class AutoMapperInitializer : IInitializable
    {
        private readonly MapperConfiguration _mapperConfiguration;

        public AutoMapperInitializer(MapperConfiguration mapperConfiguration)
        {
            _mapperConfiguration = mapperConfiguration;
        }

        public void Init()
        {
            _mapperConfiguration.AssertConfigurationIsValid();
        }
    }
}