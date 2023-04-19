using System.Threading.Tasks;
using FlightApp.Models.TokenAuth;
using FlightApp.Web.Controllers;
using Shouldly;
using Xunit;

namespace FlightApp.Web.Tests.Controllers
{
    public class HomeController_Tests: FlightAppWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}