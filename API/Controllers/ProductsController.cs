using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductType> _typeRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        public ProductsController(IGenericRepository<Product> productRepo,
                                  IGenericRepository<ProductType> typeRepo,
                                  IGenericRepository<ProductBrand> brandRepo)
        {
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;
            _productRepo = productRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductsAsync()
        {
            var spec = new ProductsWithTypesAndBrandsSpec();
            var products = await _productRepo.ListWithSpecAsync(spec);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductAsync(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpec(id);
            return await _productRepo.GetEntityWithSpecAsync(spec);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetBrandsAsync()
        {

            return Ok(await _brandRepo.AllListAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetTypesAsync()
        {
            return Ok(await _typeRepo.AllListAsync());
        }


    }
}