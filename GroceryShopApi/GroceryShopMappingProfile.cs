using AutoMapper;
using GroceryShopApi.Entities;
using GroceryShopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi
{
    public class GroceryShopMappingProfile : Profile
    {
        public GroceryShopMappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<Client, ClientDto>();
            CreateMap<CreateClientDto, Client>();
            CreateMap<CreateOrderDto, Order>();
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(o => o.DataOrder, c => c.MapFrom(s => s.Order.DataOrder));
            CreateMap<CreateOrderItemDto, OrderItem>();

        }

        
            
    }
}
