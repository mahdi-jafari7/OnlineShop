using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW_7___second_version.Database;
using HW_7___second_version.Enums;
using static HW_7___second_version.Database.Store;

namespace HW_7___second_version.Services
{
    public class ShoppingService
    {

        public StatusEnum Status { get; set; }


        public void AddToCart(int productId, int quantity)
        {
            var product = Store.SelectProduct(productId);
            if (product != null && product.Mojodi >= quantity)
            {
                //product.Mojodi -= quantity;
                for (int i = 0; i < quantity; i++)
                {

                    Store.CurrentUser.NowShoppingList.card.Add(product);
                }
                Console.WriteLine($"{quantity} x {product.Name} added to your cart.");
            }
            else
            {
                Console.WriteLine("Product not available or the product is out of mojodi");
            }
        }

        public void Checkout()
        {

            foreach (var item in CurrentUser.NowShoppingList.card)
            {
                var x = item.Id;
                Store.Products[x - 1].Mojodi--;
                // inja ba estefade az id mahsolati ke toye sabad kharid karbar hastan mitonim be mojodi on mahsol dar anbar dastresi dashte bashim va meghdaresh ro yeki kahesh bedim
            }
            Console.WriteLine("Finalizing your order...");
            decimal total = 0;
            foreach (var product in CurrentUser.NowShoppingList.card)
            {
                total += product.Price;
                Console.WriteLine($"- {product.Name} - ${product.Price}");
            }
            Console.WriteLine($"Total amount: ${total}");

            CurrentUser.shoppingList.Add(Store.CurrentUser.NowShoppingList);


        }

        public void ShowOrderHistory()
        {
            Console.Clear();
            Console.WriteLine("Your Order History:");
            int orderNumber = 1;
            foreach (var item in Store.CurrentUser.shoppingList)
            {
                Console.WriteLine($"Order {orderNumber}:");
                foreach (var item1 in item.card)
                {
                    Console.WriteLine($"- {item1.Name} - ${item1.Price}");
                }
                orderNumber++;
            }
        }
    }

}
