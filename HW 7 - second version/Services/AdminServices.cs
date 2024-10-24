using HW_7___second_version.Database;
using HW_7___second_version.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7___second_version.Services
{
    public class AdminServices
    {
        // we only provides some Services For Admin users here

        
        //1

        public void CompleteOrder()
        {
          

            Console.WriteLine("which Order do you want to confirm. enter Id");
        }

        //2
        public void AddProduct(string name, Catagoryenum catagory, decimal price, int mojodi)
        {
            int newid = Store.Products.Count;
            Product newProduct = new Product(newid, name, catagory, price, mojodi);
        }

        //3
        public void ChangeInventory(int id, int new_amount)
        {
            Store.Products[id].Mojodi = new_amount;
        }

        //4
        public void RemoveProduct(int id)
        {
            Store.Products.RemoveAt(id);
            Console.WriteLine($" {Store.Products[id]} has been Successfully removed!");
        }

        //5
        public void ShowAllOrders()
        {
            foreach (var item in Store.users)
            {
                if (item.Role == RoleEnum.Customer)
                {
                    Console.WriteLine($"All orders by : {item.Username}");
                    foreach (var item1 in item.shoppingList)
                    {
                        Console.WriteLine(item1);
                    }
                }
            }
        }

    }
}
