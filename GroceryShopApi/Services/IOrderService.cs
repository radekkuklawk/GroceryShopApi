using GroceryShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Services
{
    public interface IOrderService
    {
        Task RemoveAll(int clientId);
        Task<int> Create(int clientId, CreateOrderDto dto);
    }
}
