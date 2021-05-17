using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Models
{
    public class CreateOrderDto
    {
        public int IdClient { get; set; }
        public DateTime DataOrder { get; set; }
    }
}
