using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTfulAPI.Domain;

namespace RESTfulAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public static List<User> users = new List<User>()
        {
            new User{FirstName = "John", LastName = "Doe", Age = 13},
            new User{FirstName = "Bob", LastName = "Bobsky", Age = 26},
            new User{FirstName = "Mike", LastName = "Tyson", Age = 39}
        };

        // GET api/values
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return users;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                return users[id - 1];
            }
            catch (ArgumentOutOfRangeException)
            {

                return NotFound($"There's no user with that id!");

            } catch (Exception ex)
            {
                return BadRequest($"BROKEN {ex.Message}");
            }
        }

        [HttpGet("adults/{id}")]
        public ActionResult IsItAdult(int id)
        {
            if (users[id - 1].Age >= 18)
            {
                return Ok("The user is adult");
            }

            return NotFound("The user is minor");
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] User user)
        {
            users.Add(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            try
            {
                users[id - 1] = user;

                return Ok("The user's info has been updated.");
            }
            catch (ArgumentOutOfRangeException)
            {

                return NotFound($"There's no user with that id.");

            }
            catch (Exception ex)
            {
                return BadRequest($"BROKEN {ex.Message}");
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                users.RemoveAt(id - 1);

                return Ok("The user has been deleted.");
            }
            catch (ArgumentOutOfRangeException)
            {

                return NotFound($"There's no user with that id.");

            }
            catch (Exception ex)
            {
                return BadRequest($"BROKEN {ex.Message}");
            }
        }
    }
}
