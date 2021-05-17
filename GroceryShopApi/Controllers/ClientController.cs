using GroceryShopApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroceryShopApi.Models;
using GroceryShopApi.Entities;
using Microsoft.AspNetCore.Authorization;

namespace GroceryShopApi.Controllers
{
    [Route("api/client")]
    [ApiController]
    //[Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetAll()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDto>> Get([FromRoute] int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client is null)
            {
                return NotFound(id);
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> CreateClient([FromBody] CreateClientDto dto)
        {
            var id = await _clientService.CreateAsync(dto);
            return Created($"/api/client/{id}", null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var isDeleted = await _clientService.DeleteAsync(id);
            if (isDeleted)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
