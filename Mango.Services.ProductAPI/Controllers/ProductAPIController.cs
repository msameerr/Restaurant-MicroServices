using Mango.Services.ProductAPI.Contracts;
using Mango.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/ProductAPI")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {

        protected ResponseDto _response;
        private readonly IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }


        // GET : api/ProductAPI
        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var products = await _productRepository.GetProducts();
                _response.Result = products;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>()
                {
                    ex.ToString()
                };
            }

            return _response;
        }

        // GET : api/ProductAPI/1
        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetById(int ProductId)
        {
            try
            {
                var product = await _productRepository.GetProductById(ProductId);
                _response.Result = product;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>()
                {
                    ex.ToString()
                };
            }

            return _response;
        }


        // POST : api/ProductAPI
        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                var model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>()
                {
                    ex.ToString()
                };
            }

            return _response;
        }


        // POST : api/ProductAPI
        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                var model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>()
                {
                    ex.ToString()
                };
            }

            return _response;
        }


        // DELETE : api/ProductAPI
        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int productId)
        {
            try
            {
                bool isSuccess = await _productRepository.DeleteProduct(productId);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>()
                {
                    ex.ToString()
                };
            }

            return _response;
        }
    }
}
