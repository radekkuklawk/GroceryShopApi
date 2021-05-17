using GroceryShopApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroceryShopApi.Models;
using AutoMapper;

namespace GroceryShopApi.Services
{
    public class ClientService : IClientService
    {
        private readonly GroceryShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public ClientService(GroceryShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClientDto>> GetAllAsync()
        {
            var clients = await _dbContext
                .Clients
                .ToListAsync();
            var clientsDtos = _mapper.Map<List<ClientDto>>(clients);
            return clientsDtos;
        }

        public async Task<ClientDto> GetByIdAsync(int id)
        {
            var client = await _dbContext
                .Clients
                .FirstOrDefaultAsync(p => p.Id == id);

            if (client is null)
            {
                return null;
            }
            var clientDto = _mapper.Map<ClientDto>(client);
            return clientDto;
        }

        public async Task<int> CreateAsync(CreateClientDto dto)
        {
            var client = _mapper.Map<Client>(dto);
            await _dbContext.Clients.AddAsync(client);
            await _dbContext.SaveChangesAsync();
            return client.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var client = await _dbContext
              .Clients
              .FirstOrDefaultAsync(p => p.Id == id);
            if (client is null) return false;
            _dbContext.Clients.Remove(client);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
