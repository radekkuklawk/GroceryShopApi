using GroceryShopApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryShopApi.Services
{
    public interface IProductService
    {
        Task<int> CreateAsync(CreateProductDto dto);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}