using GummyWorld.Domain.Entities.Dtos.Product;
using GummyWorld.Domain.Entities.Models;

namespace GummyWorld.Infrastructure.Services.ProductService;

public interface IProductService
{
    Task<Response<Product>> AddProduct(AddProductDto newProduct);
    Task<Response<Product>> DeleteProduct(int id);
    Task<Response<List<Product>>> GetAllProducts();
    Task<Response<Product>> UpdateProduct(UpdateProductDto updatedProduct);
}