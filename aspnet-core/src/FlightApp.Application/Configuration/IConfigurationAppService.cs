using System.Threading.Tasks;
using FlightApp.Configuration.Dto;

namespace FlightApp.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
