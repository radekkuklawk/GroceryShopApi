using AutoMapper;
using GroceryShopApi.Entities;
using GroceryShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GroceryShopApi.Services
{
    public class ProductService : IProductService
    {
        private readonly GroceryShopDbContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(GroceryShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var product = await _dbContext
                .Products
                .FirstOrDefaultAsync(p => p.Id == id);
              
            if (product is null)
            {
                return null;
            }
            var result = _mapper.Map<ProductDto>(product);
            return result;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _dbContext
                .Products
                .ToListAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return productDtos;
        }

        public async Task<int> CreateAsync(CreateProductDto dto)
        {
            var product =_mapper.Map<Product>(dto);
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _dbContext
              .Products
              .FirstOrDefaultAsync(p => p.Id == id);
            if (product is null) return false;
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}

