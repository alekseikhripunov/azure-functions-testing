using AzureFunctionsTesting.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureFunctionsTesting.Application.Functions
{
    public class ProductsFunctions
    {
        private readonly ILogger<ProductsFunctions> _logger;

        public ProductsFunctions(ILogger<ProductsFunctions> logger)
        {
            _logger = logger;
        }

        [FunctionName("GetProducts")]
        public Task<IActionResult> GetProductsAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "products")] HttpRequest req)
        {
            _logger.LogInformation("Getting Products.");

            List<ProductModel> products = new List<ProductModel>
            {
                new ProductModel{Id = 1, Name = "VW Passat"}
            };
            IActionResult result = new OkObjectResult(products);

            return Task.FromResult(result);
        }
    }
}
