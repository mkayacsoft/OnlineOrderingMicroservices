using ProductService.Models;
using ProductService.Repositories.Interfaces;

namespace ProductService.Repositories.Implementations;

public class ProductService:IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<Product> CreateProductAsync(Product product)
    {
        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();
        return product;
    }

    public async Task<bool> UpdateProductAsync(int id, Product updateProduct)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id);
        if (existingProduct == null)
            return false;
        
        existingProduct.Name = updateProduct.Name;
        existingProduct.Price = updateProduct.Price;
        existingProduct.Stock = updateProduct.Stock;
        
        _productRepository.Update(existingProduct);
        await _productRepository.SaveChangesAsync();
        return true;
        
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var existingProduct = await _productRepository.GetByIdAsync(id);
        if (existingProduct == null)
            return false;
        _productRepository.Delete(existingProduct);
        await _productRepository.SaveChangesAsync();
        return true;
    }
}