using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;

namespace MovieStore.Controllers
{
    public class MenuController : Controller
    {
        private static List<MovieModel> list = new List<MovieModel>
        {
            new MovieModel
            {
                Id = 1,
                Title = "The Godfather",
                Genre = "Crime",
                Year = 1972,
                Price = 5.99M
            },
            new MovieModel
            {
                Id = 2,
                Title = "Saving Private Ryan",
                Genre = "War",
                Year = 1998,
                Price = 5.99M
            },
            new MovieModel
            {
                Id = 3,
                Title = "One Flew Over the Cuckoo's Nest",
                Genre = "Drama",
                Year = 1975,
                Price = 5.99M
            },
            new MovieModel
            {
                Id = 4,
                Title = "Sicario",
                Genre = "Action",
                Year = 2015,
                Price = 5.99M
            },
            new MovieModel
            {
                Id = 5,
                Title = "The Hangover",
                Genre = "Comedy",
                Year = 2009,
                Price = 5.99M
            }
        };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Movies()
        {
            return View(list);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MovieModel movie)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            list.Add(movie);

            return View("Movies", list);
        }

        public IActionResult Edit(int id)
        {
            var movie = list.FirstOrDefault(x => x.Id == id);
            
            return View(movie);
        }

        [HttpPost]
        public IActionResult SaveChanges(MovieModel movie)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit");
            }

            var index = list.FindIndex(x => x.Id == movie.Id);
            list[index] = movie;

            return View("Movies", list);
        }

        public IActionResult MovieDetails(int id)
        {
            var movie = list.FirstOrDefault(x => x.Id == id);
            
            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            var movie = list.FirstOrDefault(x => x.Id == id);
            list.Remove(movie);
            return View("Movies", list);
        }
        
        public FileResult DownloadFile(int id)
        {
            var fileName = $"MovieID{id.ToString()}.txt";
            var filepath = $"Files/{fileName}";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            return File(fileBytes, "application/txt", fileName);
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
    }
}