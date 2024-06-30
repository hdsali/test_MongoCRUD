using MongoTest7CQRS.Domain;
using MongoTest7CQRS.Infrastructure;
using MongoTest7CQRS.Application.Commands;
using MediatR;
using System.Numerics;

namespace MongoTest7CQRS.Handlers
{
    public class CreateProductHandler: IRequestHandler<CreateProductCommand, ProductDetails>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductDetails> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var productDetails = new ProductDetails()
            {
                ProductName = command.ProductName,
                ProductDescription = command.ProductDescription,
                ProductStock = command.ProductStock,
                ProductPrice = command.ProductPrice
            };

            return await _productRepository.AddProductAsync(productDetails);
        }
    }
}
