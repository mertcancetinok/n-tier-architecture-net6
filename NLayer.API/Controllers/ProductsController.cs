using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;
        public ProductsController(IProductService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();

            var dto = _mapper.Map<List<ProductDto>>(products.ToList());
            
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(HttpStatusCode.OK, dto));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetProductsWithCategoryAsync());
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(HttpStatusCode.OK, _mapper.Map<ProductDto>(product)));
        }
        
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
           
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(HttpStatusCode.Created, _mapper.Map<ProductDto>(product)));
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productUpdateDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productUpdateDto));
           
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(HttpStatusCode.NoContent));
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(product);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(HttpStatusCode.NoContent));
        }



    }
}
