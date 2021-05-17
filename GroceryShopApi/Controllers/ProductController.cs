using AutoMapper;
using GroceryShopApi.Entities;
using GroceryShopApi.Models;
using GroceryShopApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductDto>> Get([FromRoute] int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if(product is null)
            {
                return NotFound(id);
            }
            
            return Ok(product);        
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductDto dto)
        {
            var id = await _productService.CreateAsync(dto);
            return Created($"/api/product/{id}", null);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            var isDeleted = await _productService.DeleteAsync(id);
            if (isDeleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
