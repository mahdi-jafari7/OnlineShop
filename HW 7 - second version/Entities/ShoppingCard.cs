using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7___second_version.Entities
{
    public class ShoppingCard
    {

        public List<Product> card { get; set; } = new List<Product>();
        public bool Isfactor = false;
    }
}
