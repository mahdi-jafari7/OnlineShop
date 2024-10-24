using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_7___second_version.Enums;

namespace HW_7___second_version
{
    public class Product
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Mojodi { get; set; }
        

        public Catagoryenum CEnum { get; set; }

        public Product(int id, string name,Catagoryenum catagory, decimal price, int mojodi)
        {
            Id = id;
            Name = name;
            Price = price;
            Mojodi = mojodi;
        }
    }

}

