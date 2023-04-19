using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using FlightApp.EntityFrameworkCore;
using FlightApp.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace FlightApp.Web.Tests
{
    [DependsOn(
        typeof(FlightAppWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class FlightAppWebTestModule : AbpModule
    {
        public FlightAppWebTestModule(FlightAppEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FlightAppWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(FlightAppWebMvcModule).Assembly);
        }
    }
}