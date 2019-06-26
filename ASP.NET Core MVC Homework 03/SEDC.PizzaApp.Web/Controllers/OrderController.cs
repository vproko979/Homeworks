using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Domain;
using SEDC.PizzaApp.Services;

namespace SEDC.PizzaApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IService _pizzaService;

        public OrderController(IOrderService orderService, IService pizzaService)
        {
            _orderService = orderService;
            _pizzaService = pizzaService;
        }
        public IActionResult Index()
        {
            List<Order> orderList = _orderService.GetAllOrders();

            return View(orderList);
        }

        public IActionResult Create()
        {
            ViewData["Pizzas"] = _pizzaService.GetAllPizzas();
            ViewBag.Pizzas = _pizzaService.GetAllPizzas();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _orderService.CreateOrder(order);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Order order = _orderService.GetOrderById(id);

            return View(order);
        }

        public IActionResult Update(Order order)
        {
            _orderService.UpdateOrder(order);

            return View(order);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            Order order = _orderService.GetOrderById(id);

            return View(order);
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _orderService.UpdateOrder(order);

            return View("Update", order);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _orderService.DeleteOrderById(id);

            return RedirectToAction("Index");
        }
    }
}