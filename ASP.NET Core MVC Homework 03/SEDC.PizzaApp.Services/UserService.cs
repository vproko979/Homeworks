using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        public void CreateUser(User user)
        {
            _userRepository.Create(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public void DeleteUserById(int id)
        {
            _userRepository.Delete(id);
        }
    }
}
