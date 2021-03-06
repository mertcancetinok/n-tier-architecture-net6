using System.Net;
using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services;

public class ProductService:Service<Product>,IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    public ProductService(IMapper mapper,IProductRepository productRepository,IGenericRepository<Product> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategoryAsync()
    {
        var products = await _productRepository.GetProductsWithCategoryAsync();
        var dto = _mapper.Map<List<ProductWithCategoryDto>>(products);

        return CustomResponseDto<List<ProductWithCategoryDto>>.Success(HttpStatusCode.OK,dto);

    }
}