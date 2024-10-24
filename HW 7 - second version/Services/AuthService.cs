using HW_7___second_version.Database;
using HW_7___second_version.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7___second_version.Services
{
    public class AuthService
    {
        public List<User> users = new List<User>();


        public void Register(string username, string password, RoleEnum role)
        {
            int regId = Store.users.Count;
            users.Add(new User(regId,username, password, role));
            Console.WriteLine("Registration successful!");
            
        }


        public User Login(string username, string password)
        {
            {
                foreach (var user in Store.users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        Console.WriteLine("Login successful!");
                       
                        return user;
                    }
                }


                Console.WriteLine("Username or Password is wrong!");
                return null;
            }


        }
    }

}
