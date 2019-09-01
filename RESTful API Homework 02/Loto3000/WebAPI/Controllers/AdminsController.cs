using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Reflection;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;

        public AdminsController(IAdminService adminService, IUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            foreach (PropertyInfo property in model.GetType().GetProperties())
            {
                if ((string)property.GetValue(model, null) == "")
                {
                    return BadRequest("Don't leave empty fields");
                }
            }

            if (model.Password == model.ConfirmPassword)
            {
                model.Role = "Admin";

                _userService.RegisterUser(model);
                return Ok("Successfully registered!");
            }

            return BadRequest("Something went wrong, try again");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("drawing")]
        public IActionResult Drawing([FromBody] DrawingModel drawing)
        {
            var numbers = drawing.DrawnNumbers.Split(',').Select(Int32.Parse).ToList();

            if (numbers.Count != numbers.Distinct().Count())
            {
                return BadRequest("You got duplicates. Fix it");
            }

            _adminService.PublishNumbers(drawing);
            _userService.FindWinners();
            _adminService.StartSession();
            return Ok("Numbers are published.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("session")]
        public IActionResult Session()
        {
            var date = DateTime.Now;
            SessionModel session = _userService.IsItSessionActive();

            if (session != null && session.StartDate <= date && date <= session.EndDate)
            {
                return BadRequest("There's already active session");
            }
            else
            {
                _adminService.StartSession();
                return Ok("Session started");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("prize")]
        public IActionResult Prize([FromBody] PrizeModel prize)
        {
            _adminService.AddOrUpdatePrize(prize);
            return Ok("The prize was added/updated.");
        }
    }
}