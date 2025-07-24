using ECommerce.Core.Responses;
using ECommerce.Models.Dtos.Products.Requests;
using ECommerce.Models.Dtos.Products.Responses;
using ECommerce.Models.Entities;
using System.Linq.Expressions;

namespace ECommerce.Service.Abstracts;

public interface IProductService
{
  Task<ReturnModel<List<ProductResponseDto>>> GetAllAsync(
    bool enableTracking = false,
    bool withDeleted = false,
    Expression<Func<Product, bool>>? filter = null,
    Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null,
    CancellationToken cancellationToken = default);

  Task<ReturnModel<ProductResponseDto>> GetByIdAsync(Guid id);

  Task<ReturnModel<CreatedProductResponseDto>> AddAsync(CreateProductRequest request);

  Task<ReturnModel<NoData>> RemoveAsync(Guid id);

  Task<ReturnModel<NoData>> UpdateAsync(UpdateProductRequest request);

  Task ReduceStockAsync(Guid productId, int quantity);
}