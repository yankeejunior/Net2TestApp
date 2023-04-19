using System.Threading.Tasks;
using Abp.Application.Services;
using FlightApp.Sessions.Dto;

namespace FlightApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
