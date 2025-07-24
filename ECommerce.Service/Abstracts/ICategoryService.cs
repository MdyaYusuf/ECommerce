using ECommerce.Core.Responses;
using ECommerce.Models.Dtos.Categories.Requests;
using ECommerce.Models.Dtos.Categories.Responses;
using ECommerce.Models.Entities;
using System.Linq.Expressions;

namespace ECommerce.Service.Abstracts;

public interface ICategoryService
{
  Task<ReturnModel<List<CategoryResponseDto>>> GetAllAsync(
    bool enableTracking = false,
    bool withDeleted = false,
    Expression<Func<Category, bool>>? filter = null,
    Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null,
    CancellationToken cancellationToken = default);

  Task<ReturnModel<CategoryResponseDto>> GetByIdAsync(int id);

  Task<ReturnModel<CategoryResponseDto>> AddAsync(CreateCategoryRequest request);

  Task<ReturnModel<NoData>> RemoveAsync(int id);

  Task<ReturnModel<NoData>> UpdateAsync(UpdateCategoryRequest request);
}