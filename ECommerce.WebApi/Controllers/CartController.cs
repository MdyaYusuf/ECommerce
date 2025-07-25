using AutoMapper;
using ECommerce.Models.Dtos.Carts.Requests;
using ECommerce.Models.Entities;
using ECommerce.Service.Abstracts;
using ECommerce.WebApi.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CartController(ICartService _cartService, IProductService _productService, IMapper _mapper, CartSessionHelper _helper) : ControllerBase
{
  [HttpGet("get")]
  public IActionResult GetCart()
  {
    var cart = _helper.GetCartFromSession();

    return Ok(cart);
  }

  [HttpPost("add")]
  public async Task<IActionResult> AddItemAsync([FromQuery] AddCartItemRequest request)
  {
    var productResult = await _productService.GetByIdAsync(request.ProductId);
    var productEntity = _mapper.Map<Product>(productResult.Data);

    var cart = _helper.GetCartFromSession();
    _cartService.AddItem(cart, productEntity, request.Quantity);
    _helper.SaveCartToSession(cart);

    return Ok(cart);
  }

  [HttpDelete("remove")]
  public IActionResult RemoveItem([FromQuery] RemoveCartItemRequest request)
  {
    var cart = _helper.GetCartFromSession();
    _cartService.RemoveItem(cart, request.ProductId, request.Quantity);
    _helper.SaveCartToSession(cart);

    return Ok(cart);
  }

  [HttpPost("clear")]
  public IActionResult ClearCart()
  {
    var cart = _helper.GetCartFromSession();
    _cartService.ClearCart(cart);
    _helper.SaveCartToSession(cart);

    return Ok(cart);
  }
}