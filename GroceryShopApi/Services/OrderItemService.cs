using AutoMapper;
using GroceryShopApi.Entities;
using GroceryShopApi.Exceptions;
using GroceryShopApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly GroceryShopDbContext _context;
        private readonly IMapper _mapper;

        public OrderItemService(GroceryShopDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }


        public async Task<OrderItemDto> GetById(int orderId, int productId, int orderItemId)
        {
            var order = GetOrderById(orderId);
            var product = GetProdcutById(productId);
            var orderItem = await _context.OrderItems.Include(o => o.Order).FirstOrDefaultAsync(i => i.Id == orderItemId);
            if (order is null || product is null || orderItem is null || orderItem.IdOrder != orderId || orderItem.IdProduct != productId)
            {
                throw new NotFoundException("Order not found");
            }

            var orderDto = _mapper.Map<OrderItemDto>(orderItem);
            return orderDto;
        }


        private async Task<Order> GetOrderById(int orderId)
        {
            var order = await _context
                 .Orders
                 .FirstOrDefaultAsync(o => o.Id == orderId);

            if (order is null)
                throw new NotFoundException("Order not found");

            return order;
        }

        private async Task<Product> GetProdcutById(int productId)
        {

            var product = await _context
                 .Products
                 .FirstOrDefaultAsync(p => p.Id == productId);

            if (product is null)
                throw new NotFoundException("Product not found");

            return product;

        }

        public async Task<int> Create (int orderId, int productId, CreateOrderItemDto dto)
        {
            var order = await GetOrderById(orderId);
            var product = await GetProdcutById(productId);
            var orderItemEntity = _mapper.Map<OrderItem>(dto);
            orderItemEntity.IdOrder = orderId;
            orderItemEntity.IdProduct = productId;
            await _context.OrderItems.AddAsync(orderItemEntity);
            await _context.SaveChangesAsync();

            return orderItemEntity.Id;


        }
        public async Task<bool> Delete(int orderId, int productId, int orderItemId)
        {
            var order = GetOrderById(orderId);
            var product = GetProdcutById(productId);
            var orderItem = await _context.OrderItems.FirstOrDefaultAsync(i => i.Id == orderItemId);
            if (order is null || product is null || orderItem is null || orderItem.IdOrder != orderId || orderItem.IdProduct != productId)
            {
                throw new NotFoundException("Order not found");
            }
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}