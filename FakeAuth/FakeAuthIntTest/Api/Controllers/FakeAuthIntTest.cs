using System.Net;
using System.Threading.Tasks;
using FakeAuth;
using FakeAuthIntTest.FakeAuthHelpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace FakeAuthIntTest.Api.Controllers
{
    public class FakeAuthTest
    {
        [Fact]
        public async Task Should_Return_401_With_Normal_Authentication()
        {
            //arrange
            var webHostBuilder = new WebHostBuilder().UseStartup<Startup>();
            using var server = new TestServer(webHostBuilder);
            using var client = server.CreateClient();

            
            // Act
            var response = await client.GetAsync("/protected");
            
            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
        
        [Fact]
        public async Task Should_Return_200_With_Fake_Authentication()
        {
            //arrange
            var webHostBuilder = new WebHostBuilder().UseStartup<FakeAuthStartup>();
            using var server = new TestServer(webHostBuilder);
            using var client = server.CreateClient();
            
            // Act
            var response = await client.GetAsync("/protected");
            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}