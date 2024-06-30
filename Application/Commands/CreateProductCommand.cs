using MediatR;
using MongoTest7CQRS.Domain;

namespace MongoTest7CQRS.Application.Commands
{
        public class CreateProductCommand : IRequest<ProductDetails>
        {
            public string ProductName { get; set; }
            public string ProductDescription { get; set; }
            public int ProductPrice { get; set; }
            public int ProductStock { get; set; }

        public CreateProductCommand(string ProductName, string ProductDescription, int ProductPrice, int ProductStock)
            {
                ProductName = ProductName;
                ProductDescription = ProductDescription;
                ProductPrice = ProductPrice;
                ProductStock = ProductStock;
            }
        }
    }

