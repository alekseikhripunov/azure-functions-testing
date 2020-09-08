using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AzureFunctionsTesting.IntegrationTests
{
    public class ProductsFunctionsTests
    {
        public ProductsFunctionsTests()
        {

        }

        [Fact]
        public async Task GetProductsAsync_AnyQueryParams_ProductsReturned()
        {
            using var httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:7071") };

            var response = await httpClient.GetAsync("api/products");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
