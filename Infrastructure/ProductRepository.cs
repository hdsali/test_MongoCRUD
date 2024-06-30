using MongoTest7CQRS.Configurations;
using MongoTest7CQRS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Numerics;
using MongoTest7CQRS.Infrastructure;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MongoTest7CQRS.Configurations
{
        public class ProductRepository : IProductRepository
        {
            private readonly DbContextClass _dbContext;

            public ProductRepository(DbContextClass dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ProductDetails> AddProductAsync(ProductDetails ProductDetails)
            {
                var result = _dbContext.Products.Add(ProductDetails);
                await _dbContext.SaveChangesAsync();
                return result.Entity;
            }

            public async Task<int> DeleteProductAsync(string Id)
            {
                var filteredData = _dbContext.Products.Where(x => x.Id == Id).FirstOrDefault();
                _dbContext.Products.Remove(filteredData);
                return await _dbContext.SaveChangesAsync();
            }

            public async Task<ProductDetails> GetProductByIdAsync(string Id)
            {
                return await _dbContext.Products.Where(x => x.Id == Id).FirstOrDefaultAsync();
            }


        private readonly IMongoCollection<ProductDetails> productCollection;
        public ProductRepository(IOptions<ProductDBSettings> productDatabaseSetting)
        {
            var mongoClient = new MongoClient(productDatabaseSetting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(productDatabaseSetting.Value.DatabaseName);
            productCollection = mongoDatabase.GetCollection<ProductDetails>(productDatabaseSetting.Value.ProductCollectionName);
        }

        public async Task<List<ProductDetails>> GetProductListAsync_Mongo()
        {
            return await productCollection.Find(_ => true).ToListAsync();
        }
        public async Task<List<ProductDetails>> GetProductListAsync()
            {
                return await _dbContext.Products.ToListAsync();
            }

            public async Task<int> UpdateProductAsync(ProductDetails ProductDetails)
            {
                _dbContext.Products.Update(ProductDetails);
                return await _dbContext.SaveChangesAsync();
            }
        }
    }
