
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepositry _repositry;

        public ProductsController(IProductRepositry repositry)
        {
            _repositry = repositry;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repositry.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await _repositry.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands(){

            var productBrands=await _repositry.GetProductBrandsAsync();
            return Ok(productBrands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes(){
            var productTypes=await _repositry.GetProductTypesAsync();
            return Ok(productTypes);
        }
    }
}
