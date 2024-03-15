using GummyWorld.Domain.Entities.Dtos.Product;
using GummyWorld.Domain.Entities.Models;
using GummyWorld.Infrastructure.Services.ProductService;
using Microsoft.AspNetCore.Mvc;

namespace GummyWorld.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<Response<List<Product>>>> Get()
    {
        return Ok(await _productService.GetAllProducts());
    }

    [HttpPost]
    public async Task<ActionResult<Response<Product>>> AddProduct(AddProductDto newProduct)// doar "Add" AddProduct e superfluu
    {
        return Ok(await _productService.AddProduct(newProduct));// doar "Add" AddProduct e superfluu
    }

    [HttpPut]
    public async Task<ActionResult<Response<Product>>> UpdateProduct(UpdateProductDto updateProductDto)
    {
        var response = await _productService.UpdateProduct(updateProductDto);
        if(response.Result == null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }

    [HttpDelete]
    public async Task<ActionResult<Response<Product>>> DeleteProduct(int id)
    {
        var response = await _productService.DeleteProduct(id);
        if(response.Result == null)
        {
            return NotFound(response);
        }
        return Ok(response);
    }
}
