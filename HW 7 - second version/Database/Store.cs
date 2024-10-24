using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_7___second_version.Enums;

namespace HW_7___second_version.Database
{
    public static class Store
    {
        //public List<User> users = new List<User>();
        public static List<Product> Products { get; set; } = new List<Product>();
        public static List<User> users { get; set; } = new List<User>();

        public static User CurrentUser = new User(1000,"test","test",RoleEnum.Customer);
        public static List<List<Product>> PendList { get; set; } = new List<List<Product>>();
        //public static Dictionary<string, List<List<Product>> > PendOrderDictionary = new Dictionary<string, List<List<Product>>>();
        static Store()
        {

            Products.Add(new Product(1, "MacBook M3 Pro", Catagoryenum.laptop, 1500, 10));
            Products.Add(new Product(2, "Iphone 16", Catagoryenum.smartphone, 800, 20));
            Products.Add(new Product(3, "AirPad 2", Catagoryenum.airpod, 150, 30));


            users.Add(new User(1, "mahdi.jafari", "mahdi@123", RoleEnum.Customer));
            users.Add(new User(2, "ali.jafari", "ali@123", RoleEnum.Customer));
            users.Add(new User(3, "javad.jafari", "javad@123", RoleEnum.Customer));

            
        }


        public static void ShowProducts()
        {

            Console.WriteLine("\n======== Product List ========");
            Console.WriteLine("Available Products:");
            foreach (var product in Products)
            {
                Console.WriteLine($"{product.Id}. {product.Name} - Catagory: {product.CEnum} - Price: ${product.Price} (mojodi: {product.Mojodi})");
            }
        }


        public static Product SelectProduct(int id)
        {
            foreach (var product in Products)
            {
                if (product.Id == id && product.Mojodi > 0)
                {
                    return product;
                }
            }
            return null;
        }
    }

}

