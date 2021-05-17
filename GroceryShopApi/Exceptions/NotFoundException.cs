using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string meesage) : base(meesage)
        {
                
        }

    }
}
