using GroceryShopApi.Models;
using System.Threading.Tasks;

namespace GroceryShopApi.Services
{
    public interface IOrderItemService
    {
        Task<OrderItemDto> GetById(int orderId, int productId, int orderItemId);
        Task<int> Create(int orderId, int productId, CreateOrderItemDto dto);
        Task<bool> Delete(int orderId, int productId, int orderItemId);

    }
}