using System.Threading.Tasks;
using Souccar.Models.TokenAuth;
using Souccar.Web.Controllers;
using Shouldly;
using Xunit;

namespace Souccar.Web.Tests.Controllers
{
    public class HomeController_Tests: SouccarWebTestBase
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