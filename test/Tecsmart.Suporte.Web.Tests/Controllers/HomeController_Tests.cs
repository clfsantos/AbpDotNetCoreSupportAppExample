using System.Threading.Tasks;
using Tecsmart.Suporte.Models.TokenAuth;
using Tecsmart.Suporte.Web.Controllers;
using Shouldly;
using Xunit;

namespace Tecsmart.Suporte.Web.Tests.Controllers
{
    public class HomeController_Tests: SuporteWebTestBase
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