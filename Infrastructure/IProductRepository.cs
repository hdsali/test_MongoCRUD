using MongoTest7CQRS.Domain;
namespace MongoTest7CQRS.Infrastructure
{
    public interface IProductRepository
        {
            public Task<List<ProductDetails>> GetProductListAsync();
            public Task<ProductDetails> GetProductByIdAsync(string Id);
            public Task<ProductDetails> AddProductAsync(ProductDetails productDetails);
            public Task<int> UpdateProductAsync(ProductDetails productDetails);
            public Task<int> DeleteProductAsync(string Id);
        }
}

