using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Core.Specifications;
using API.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using API.Errors;
using API.Helpers;


namespace API.Controllers
{
//    [ApiController]
// [Route("api/[controller]")]
public class ProductsController : BaseApiController
{

  private readonly IGenercRepository<Product> _productRepo;
  private readonly IGenercRepository<ProductBrand> _productBrandRepo;
  private readonly IGenercRepository<ProductType> _productTypeRepo;
  private readonly IMapper _mapper;
    public ProductsController(IGenercRepository<Product> productRepo,
    IGenercRepository<ProductBrand> productBrandRepo,
    IGenercRepository<ProductType> productTypeRepo,
    IMapper mapper)
    {
   _productRepo = productRepo;
   _productBrandRepo = productBrandRepo;
   _productTypeRepo = productTypeRepo;
   _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
       [FromQuery]ProductSpecParams productParams)
    {
        var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
        var countSpec = new ProductWithFilterForCountSpecification(productParams);
        var totalItem = await _productRepo.CountAsync(countSpec);
        var products = await _productRepo.ListAsync(spec);
        var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
        return Ok(new Pagination<ProductToReturnDto>(productParams.PageIndex,productParams.PageSize, totalItem,data));
        
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
    {
        var spec = new ProductsWithTypesAndBrandsSpecification(id);
        var product = await _productRepo.GetEntityWithSpec(spec);
if(product == null) return NotFound(new ApiResponse(404));
return _mapper.Map<Product, ProductToReturnDto>(product);
    }
    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands(){
        return Ok(await _productBrandRepo.ListAllAsync());
    }
     [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes(){
        return Ok(await _productTypeRepo.ListAllAsync());
    }
}

}