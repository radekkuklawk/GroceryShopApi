using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Models
{
    public class CreateClientDto
    {
      
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
    }
}
