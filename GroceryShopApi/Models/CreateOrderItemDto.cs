using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Models
{
    public class CreateOrderItemDto
    {
        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }

    }
}
