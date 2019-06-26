using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Domain;
using SEDC.PizzaApp.Services;
using SEDC.PizzaApp.Web.ViewModels;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IService _pizzaService;

        public PizzaController(IService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        public IActionResult Index()
        {
            List<Pizza> pizzaList = _pizzaService.GetAllPizzas();

            MenuViewModel menu = new MenuViewModel("Pizza House", pizzaList);
            

            return View(menu);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            _pizzaService.CreatePizza(pizza);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Pizza pizza = _pizzaService.GetPizzaById(id);

            return View(pizza);
        }

        
        public IActionResult Update(Pizza pizza)
        {
            _pizzaService.UpdatePizza(pizza);

            return View(pizza);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Pizza pizza = _pizzaService.GetPizzaById(id);

            return View(pizza);
        }

        [HttpPost]
        public IActionResult Edit(Pizza pizza)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _pizzaService.UpdatePizza(pizza);

            return View("Update", pizza);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _pizzaService.DeletePizzaById(id);

            return RedirectToAction("Index");
        }
    }
}