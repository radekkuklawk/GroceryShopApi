using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int IdClient { get; set; }
        public DateTime DataOrder { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; }
        public virtual Client Client { get; set; }
    }
}
