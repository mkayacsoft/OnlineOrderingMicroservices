using ProductService.Models;

namespace ProductService.Repositories.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<Product> CreateProductAsync(Product product);
    Task<bool> UpdateProductAsync(int id,Product updateProduct);
    Task<bool> DeleteProductAsync(int id);
}