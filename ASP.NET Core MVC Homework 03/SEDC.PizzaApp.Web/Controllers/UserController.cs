using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Domain;
using SEDC.PizzaApp.Services;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            List<User> userList = _userService.GetAllUsers();

            return View(userList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _userService.CreateUser(user);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            User user = _userService.GetUserById(id);

            return View(user);
        }


        public IActionResult Update(User user)
        {
            _userService.UpdateUser(user);

            return View(user);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            User user = _userService.GetUserById(id);

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _userService.UpdateUser(user);

            return View("Update", user);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUserById(id);

            return RedirectToAction("Index");
        }
    }
}