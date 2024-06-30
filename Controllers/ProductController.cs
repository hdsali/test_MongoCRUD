using Microsoft.AspNetCore.Mvc;
using MongoTest7CQRS.Domain;
using MediatR;
using MongoTest7CQRS.Application;
using MongoTest7CQRS.Application.Queries;
using MongoTest7CQRS.Application.Commands;

namespace MongoTest7CQRS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<ProductDetails>> GetProductList()
        {
            var productDetails = await mediator.Send(new GetProductListQuery());

            return productDetails;
        }




        //[HttpGet("productId")]
        //public async Task<ProductDetails> GetProductByIdAsync(int productId)
        //{
        //    var productDetails = await mediator.Send(new GetProductByIdQuery() { Id = productId });

        //    return productDetails;
        //}

        [HttpPost]
        public async Task<ProductDetails> AddProduct(ProductDetails productDetails)
        {
            var productDetail = await mediator.Send(new CreateProductCommand(
                productDetails.ProductName,
                productDetails.ProductDescription,
                productDetails.ProductStock,
                productDetails.ProductPrice));
            return productDetail;
        }

        //[HttpPut]
        //public async Task<int> UpdateProduct(ProductDetails productDetails)
        //{
        //    var isProductDetailUpdated = await mediator.Send(new UpdateProductCommand(
        //       productDetails.Id,
        //       productDetails.ProductName,
        //       productDetails.ProductDescription,
        //       productDetails.ProductPrice,
        //       productDetails.ProductStock));
        //    return isProductDetailUpdated;
        //}

        //[HttpDelete]
        //public async Task<int> DeleteProduct(int Id)
        //{
        //    return await mediator.Send(new DeleteProductCommand() { Id = Id });
        //}
    }




    #region oldControlerForMongoCRUD
    //[Route("api/[controller]")]
    //    [ApiController]
    //    public class ProductsController : ControllerBase
    //    {
    //        private readonly IProductService productService;
    //        public ProductsController(IProductService productService) => this.productService = productService;
    //        [HttpGet]
    //        public async Task<List<ProductDetails>> Get()
    //        {
    //            return await productService.ProductListAsync();
    //        }
    //        [HttpGet("{productId:length(24)}")]
    //        public async Task<ActionResult<ProductDetails>> Get(string productId)
    //        {
    //            var productDetails = await productService.GetProductDetailByIdAsync(productId);
    //            if (productDetails is null)
    //            {
    //                return NotFound();
    //            }
    //            return productDetails;
    //        }
    //        [HttpPost]
    //        public async Task<IActionResult> Post(ProductDetails productDetails)
    //        {
    //            await productService.AddProductAsync(productDetails);
    //            return CreatedAtAction(nameof(Get), new
    //            {
    //                id = productDetails.Id
    //            }, productDetails);
    //        }
    //        [HttpPut("{productId:length(24)}")]
    //        public async Task<IActionResult> Update(string productId, ProductDetails productDetails)
    //        {
    //            var productDetail = await productService.GetProductDetailByIdAsync(productId);
    //            if (productDetail is null)
    //            {
    //                return NotFound();
    //            }
    //            productDetails.Id = productDetail.Id;
    //            await productService.UpdateProductAsync(productId, productDetails);
    //            return Ok();
    //        }
    //        [HttpDelete("{productId:length(24)}")]
    //        public async Task<IActionResult> Delete(string productId)
    //        {
    //            var productDetails = await productService.GetProductDetailByIdAsync(productId);
    //            if (productDetails is null)
    //            {
    //                return NotFound();
    //            }
    //            await productService.DeleteProductAsync(productId);
    //            return Ok();
    //        }
    //    }
    #endregion
}




