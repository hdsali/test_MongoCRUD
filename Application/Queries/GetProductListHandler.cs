using MongoTest7CQRS.Domain;
using MongoTest7CQRS.Configurations;
using MongoTest7CQRS.Infrastructure;
using MediatR;
using System.Numerics;
using MongoTest7CQRS.Application.Queries;

namespace MongoTest7CQRS.Handlers
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<ProductDetails>>
    {
        private readonly IProductRepository _ProductRepository;

        public GetProductListHandler(IProductRepository ProductRepository)
        {
            _ProductRepository = ProductRepository;
        }

        public async Task<List<ProductDetails>> Handle(GetProductListQuery query, CancellationToken cancellationToken)
        {
            //return await _ProductRepository.getpro();
            return await _ProductRepository.GetProductListAsync();
        }
    }
}
