using AutoMapper;
using ECommerce.Models.Dtos.Categories.Requests;
using ECommerce.Models.Dtos.Categories.Responses;
using ECommerce.Models.Dtos.Orders.Requests;
using ECommerce.Models.Dtos.Orders.Responses;
using ECommerce.Models.Dtos.Products.Requests;
using ECommerce.Models.Dtos.Products.Responses;
using ECommerce.Models.Entities;

namespace ECommerce.Service.Profiles;

public class MappingProfiles : Profile
{
  public MappingProfiles()
  {
    CreateMap<CreateOrderRequest, Order>()
      .ForMember(o => o.OrderDetails, opt => opt.Ignore())
      .ForMember(o => o.Total, opt => opt.Ignore())
      .ForMember(o => o.OrderDate, opt => opt.Ignore());
    CreateMap<Order, OrderResponseDto>();

    CreateMap<CreateCategoryRequest, Category>();
    CreateMap<UpdateCategoryRequest, Category>();
    CreateMap<Category, CategoryResponseDto>();

    CreateMap<CreateProductRequest, Product>();
    CreateMap<UpdateProductRequest, Product>();
    CreateMap<Product, CreatedProductResponseDto>();
    CreateMap<Product, ProductResponseDto>()
      .ForMember(prd => prd.Category, opt => opt.MapFrom(p => p.Category.Name)).ReverseMap().ForMember(prd => prd.Category, opt => opt.Ignore());
  }
}