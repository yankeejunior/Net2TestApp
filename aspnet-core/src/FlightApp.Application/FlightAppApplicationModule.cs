using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FlightApp.Authorization;

namespace FlightApp
{
    [DependsOn(
        typeof(FlightAppCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class FlightAppApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<FlightAppAuthorizationProvider>();
            // custom maper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomMapper.CreateMapping);

        }

        public override void Initialize()
        {
            var thisAssembly = typeof(FlightAppApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
