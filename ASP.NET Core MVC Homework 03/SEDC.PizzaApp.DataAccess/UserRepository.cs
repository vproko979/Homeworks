using SEDC.PizzaApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess
{
    public class UserRepository : IRepository<User>
    {
        public List<User> GetAll()
        {
            return StorageDB.Users;
        }

        public User GetById(int id)
        {
            return StorageDB.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Create(User user)
        {
            StorageDB.UserId++;
            user.Id = StorageDB.UserId;
            StorageDB.Users.Add(user);
        }


        public void Update(User entity)
        {
            User user = StorageDB.Users.SingleOrDefault(x => x.Id == entity.Id);
            if(user != null)
            {
                int index = StorageDB.Users.IndexOf(user);
                StorageDB.Users[index] = entity;
            }
        }

        public void Delete(int id)
        {
            User user = StorageDB.Users.SingleOrDefault(x => x.Id == id);
            if(user != null)
            {
                StorageDB.Users.Remove(user);
            }
        }
    }
}
