using ECommerce.DataAccess.Abstracts;
using ECommerce.DataAccess.Concretes;
using ECommerce.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.DataAccess.Extensions;

public static class DataAccessDependencies
{
  public static IServiceCollection AddDataAccessDependencies(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddScoped<IProductRepository, EfProductRepository>();
    services.AddScoped<ICategoryRepository, EfCategoryRepository>();
    services.AddScoped<IOrderRepository, EfOrderRepository>();
    services.AddDbContext<BaseDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
    return services;
  }
}