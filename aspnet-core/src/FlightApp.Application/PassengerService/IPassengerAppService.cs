using Abp.Application.Services;
using FlightApp.PassengerHelpers.Dto;

namespace FlightApp.PassengerService
{
    public interface IPassengerAppService : IAsyncCrudAppService<PassengerDto>
    {
    }
}
