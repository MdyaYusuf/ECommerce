using ECommerce.Models.Dtos.Orders.Requests;
using ECommerce.Service.Abstracts;
using ECommerce.WebApi.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController(IOrderService _orderService, CartSessionHelper _helper) : CustomBaseController
{
  [HttpGet("getbyid/{id}")]
  public async Task<IActionResult> GetOrderByIdAsync([FromRoute] int id)
  {
    var result = await _orderService.GetOrderByIdAsync(id);

    return Ok(result);
  }

  [HttpPost("create")]
  public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderRequest request)
  {
    var userId = GetUserId();

    var cart = _helper.GetCartFromSession();

    var result = await _orderService.CreateOrderAsync(request, cart, userId);

    return Ok(result);
  }
}