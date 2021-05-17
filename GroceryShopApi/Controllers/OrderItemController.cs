using GroceryShopApi.Models;
using GroceryShopApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Controllers
{
    [Route("api/order/{orderId}/product/{productId}/orderitem")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpGet("{orderItemId}")]
        public async Task<ActionResult<OrderItemDto>> GetAll([FromRoute] int orderId, [FromRoute] int productId, [FromRoute] int orderItemId)
        {
            var orderItem = await _orderItemService.GetById(orderId, productId, orderItemId);
            return Ok(orderItem);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromRoute] int orderId, [FromRoute] int productId, [FromBody] CreateOrderItemDto dto)
        {
            var newOrderItemId = await _orderItemService.Create(orderId, productId, dto);
            return Created($"api / order /{ orderId}/ product /{ productId}/ orderitem/{newOrderItemId}", null);
        }

        [HttpDelete("{orderItemId}")]
        public async Task<ActionResult> Remove([FromRoute] int orderId, [FromRoute] int productId, [FromRoute] int orderItemId)
        {
            await _orderItemService.Delete(orderId, productId, orderItemId);
            return NoContent();
        }
    }
}
