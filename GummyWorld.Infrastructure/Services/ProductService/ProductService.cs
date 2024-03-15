using AutoMapper;
using GummyWorld.Domain.Entities.Dtos.Product;
using GummyWorld.Domain.Entities.Models;
using GummyWorld.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GummyWorld.Infrastructure.Services.ProductService;

public class ProductService : IProductService
{
    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public ProductService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<Response<List<Product>>> GetAllProducts()
    {
        var response = new Response<List<Product>>();
        var dbProducts = await _context.Products.ToListAsync();

        response.Result = dbProducts;
        response.Success = true;
        response.Message = "Received all products.";

        return response;
    }

    public async Task<Response<Product>> AddProduct(AddProductDto newProduct)
    {
        var response = new Response<Product>();
        var product = _mapper.Map<Product>(newProduct);
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        response.Result = await _context.Products.FirstOrDefaultAsync(p => p.Denumire == product.Denumire);
        response.Success = true;
        response.Message = "Product has been created.";
        return response;
    }

    public async Task<Response<Product>> UpdateProduct(UpdateProductDto updatedProduct)
    {
        var response = new Response<Product>();
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == updatedProduct.Id);

        if (product == null)
        {
            response.Message = $"Product with Id '{updatedProduct.Id}' could not be found.";
            response.Result = null;
            return response;
        }

        product.Denumire = updatedProduct.Denumire;
        product.Stoc = updatedProduct.Stoc;
        product.Pret = updatedProduct.Pret;

        _context.Products.Update(product);
        await _context.SaveChangesAsync();

        response.Success = true; 
        response.Message = $"Product with Id '{updatedProduct.Id}' has been updated.";
        response.Result = product;

        return response;
    }

    public async Task<Response<Product>> DeleteProduct(int id)
    {
        var response = new Response<Product>();

        try
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                response.Message = $"Product with Id '{id}' could not be found.";
                response.Result = null;
                return response;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            response.Result = product;
            response.Success = true;
            response.Message = $"Product with Id '{id}' has been deleted";
        }
        catch (Exception ex)
        {
            response.Message = ex.Message;
        }

        return response;
    }
}
