using MongoTest7CQRS.Domain;


namespace MongoTest7CQRS.Application
{
   public interface IProductService
        {
            public Task<List<ProductDetails>> ProductListAsync();
            public Task<ProductDetails> GetProductDetailByIdAsync(string productId);
            public Task AddProductAsync(ProductDetails productDetails);
            public Task UpdateProductAsync(string productId, ProductDetails productDetails);
            public Task DeleteProductAsync(String productId);
        }
    }

