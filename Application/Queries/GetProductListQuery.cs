using MediatR;
using MongoTest7CQRS.Domain;


namespace MongoTest7CQRS.Application.Queries
{
      public class GetProductListQuery : IRequest<List<ProductDetails>>
      {
        
      }
    
}

