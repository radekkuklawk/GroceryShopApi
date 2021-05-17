using GroceryShopApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GroceryShopApi.Services
{
    public interface IClientService
    {
        Task<ClientDto> GetByIdAsync(int id);
        Task<IEnumerable<ClientDto>> GetAllAsync();
        Task<int> CreateAsync(CreateClientDto dto);
        Task<bool> DeleteAsync(int id);
    }
}