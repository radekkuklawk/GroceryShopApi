using AutoMapper;
using GroceryShopApi.Entities;
using GroceryShopApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly GroceryShopDbContext _dbContext;
        private readonly IMapper _mapper;
        public OrderService(GroceryShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> Create (int clientId, CreateOrderDto dto)
        {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == clientId);
            var orderEntity = _mapper.Map<Order>(dto);
            orderEntity.IdClient = clientId;
            await _dbContext.Orders.AddAsync(orderEntity);
            await _dbContext.SaveChangesAsync();
            return orderEntity.Id;
        }
        public async Task RemoveAll (int clientId)
        {
            var client = await _dbContext.Clients.FirstOrDefaultAsync(c => c.Id == clientId);
            _dbContext.RemoveRange(client.Orders);
            await _dbContext.SaveChangesAsync();
        }
    }
}
