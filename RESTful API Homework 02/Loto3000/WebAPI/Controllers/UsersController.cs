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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginModel model)
        {
            var user = _userService.Authenticate(model.UserName, model.Password);

            if (user == null) return NotFound("Incorrect username or password");

            return Ok(user);
        }

        [AllowAnonymous]
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
                model.Role = "User";

                _userService.RegisterUser(model);
                return Ok("Successfully registered!");
            }

            return BadRequest("Something went wrong, try again");

        }

        [Authorize(Roles = "User")]
        [HttpPost("ticket")]
        public IActionResult Ticket([FromBody] TicketModel ticket)
        {
            List<int> list = ticket.Numbers.Split(',').Select(Int32.Parse).ToList();

            if (list.Count != list.Distinct().Count())
            {
                return BadRequest("You got duplicates. Fix it");
            }

            _userService.FillOutTicket(ticket);
            return Ok("The ticket it's in game.");
        }

        [AllowAnonymous]
        [HttpGet("active")]
        public IActionResult Active()
        {
            var date = DateTime.Now;
            SessionModel session = _userService.IsItSessionActive();

            if(session == null)
            {
                return BadRequest("Closed for betting at the moment");
            }

            if (session.StartDate <= date && date <= session.EndDate)
            {
                return Ok("Open for betting");
            }

            return BadRequest("Closed for betting at the moment");
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("last")]
        public IActionResult Last()
        {
            SessionModel lastSession = _userService.IsItSessionActive();

            return Ok(lastSession);
        }

        [AllowAnonymous]
        [HttpGet("winners")]
        public IActionResult Winners()
        {
            IEnumerable<WinnersModel> winners = _userService.GetWinners();
            WinnersModel[] list = winners.Cast<WinnersModel>().ToArray();

            if (list.Length <= 0)
            {
                return BadRequest("No winners this time, more luck next time.");
            }

            return Ok(list);
        }
    }
}