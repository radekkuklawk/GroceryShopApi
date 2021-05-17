using GroceryShopApi.Models;
using GroceryShopApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Controllers
{
    [Route("api/client{clientId}/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromRoute] int clientId, [FromBody] CreateOrderDto dto)
        {
            var newOrderId = await _orderService.Create(clientId, dto);

            return Created($"api/client/{clientId}/order/{newOrderId}", null);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromRoute] int clientId)
        {
            await _orderService.RemoveAll(clientId);
            return NoContent();
        }

       
    }


}
