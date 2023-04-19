using Abp.Application.Services;
using FlightApp.MultiTenancy.Dto;

namespace FlightApp.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

