using SEDC.PizzaApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUserById(int id);
    }
}
