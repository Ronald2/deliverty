using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<ProductType> _typeRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        public ProductsController(IGenericRepository<Product> productRepo,
                                  IGenericRepository<ProductType> typeRepo,
                                  IGenericRepository<ProductBrand> brandRepo,
                                  IMapper mapper)
        {
            _brandRepo = brandRepo;
            _typeRepo = typeRepo;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductDto>>> GetProductsAsync([FromQuery] ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpec(productParams);
            var countSpec = new ProductWithFiltersForCountSpec(productParams);
            var totalItems = await _productRepo.CountAsync(countSpec);
            var products = await _productRepo.ListWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
            return Ok(new Pagination<ProductDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductAsync(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpec(id);
            var product = await _productRepo.GetEntityWithSpecAsync(spec);
            return _mapper.Map<Product, ProductDto>(product);
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