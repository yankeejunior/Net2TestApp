using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using FlightApp.Configuration.Dto;

namespace FlightApp.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FlightAppAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
