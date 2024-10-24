using HW_7___second_version.Database;
using HW_7___second_version.Entities;
using HW_7___second_version.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7___second_version
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
        public string FullName { get; set; }

        public ShoppingCard NowShoppingList { get; set; } = new ShoppingCard();
        public List<ShoppingCard> shoppingList { get; set; } = new List<ShoppingCard>();

        public User(int id, string username, string password, RoleEnum role)
        {
            ID = id;
            Username = username;
            Password = password;
            Role = role;
            FullName = FirstName + "" + LastName;
        }


       
    }

}

