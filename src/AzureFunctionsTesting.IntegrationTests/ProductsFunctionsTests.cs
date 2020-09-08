using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Permissions;
using System.Threading.Tasks;
using Xunit;

namespace AzureFunctionsTesting.IntegrationTests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }

    public class ProductsFunctionsTests
    {
        private readonly IWebHost _host;

        public ProductsFunctionsTests()
        {
            _host = new WebHostBuilder()
                .UseUrls("http:localhost:7072")
                .UseStartup<Startup>()
                .Build();

            _host.RunAsync();
        }

        [Fact]
        public async Task GetProductsAsync_AnyQueryParams_ProductsReturned()
        {
            using var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:7072/") };

            var response = await httpClient.GetAsync("api/products");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
