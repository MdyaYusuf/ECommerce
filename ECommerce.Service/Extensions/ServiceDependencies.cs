using ECommerce.DataAccess.Abstracts;
using ECommerce.DataAccess.Concretes;
using ECommerce.Service.Abstracts;
using ECommerce.Service.Concretes;
using ECommerce.Service.Profiles;
using ECommerce.Service.Rules;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.Service.Extensions;

public static class ServiceDependencies
{
  public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
  {
    services.AddAutoMapper(typeof(MappingProfiles));
    services.AddScoped<OrderBusinessRules>();
    services.AddScoped<CartBusinessRules>();
    services.AddScoped<ProductBusinessRules>();
    services.AddScoped<CategoryBusinessRules>();
    services.AddScoped<UserBusinessRules>();
    services.AddScoped<RoleBusinessRules>();

    services.AddScoped<IUnitOfWork, UnitOfWork>();
    services.AddScoped<IOrderService, OrderService>();
    services.AddScoped<ICartService, CartService>();
    services.AddScoped<IJwtService, JwtService>();
    services.AddScoped<IAuthenticationService, AuthenticationService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IRoleService, RoleService>();
    services.AddScoped<IProductService, ProductService>();
    services.AddScoped<ICategoryService, CategoryService>();

    services.AddFluentValidationAutoValidation();
    services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    return services;
  }
}
