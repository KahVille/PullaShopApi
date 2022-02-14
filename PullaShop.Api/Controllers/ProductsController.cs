using Microsoft.AspNetCore.Mvc;
using PullaShop.Api.DataAccess.DatabaseAccess;
using PullaShop.Api.DataAccess.Data;
using PullaShop.Api.Models;

namespace PullaShop.Api.Controllers;

 [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IConfiguration Configuration;

        public ProductsController(ILogger<ProductsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<ProductModel>>> GetAllProducts()
        {
            var dataAccess = new SqlDataAccess(Configuration);
            var productData = new ProductData(dataAccess);
            var products = await productData.GetAllProducts();

            if (products is null || products?.Count <= 0)
                return NotFound(products);

            return Ok(products);
        }
    }