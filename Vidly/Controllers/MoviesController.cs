using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = new Movie() { Name = "Lotr" };
            var customers = new List<Customer>
            {
                new Customer() { Name = "Customer 1"},
                new Customer() { Name = "Customer 2"}
            };

            var randomMovies = new RandomMovieViewModel {
                Movie=movies,
                Customers = customers
            };
            return View(randomMovies);

        }
        [Route("movies/released/{year}/{month:regex(\\d{4})}")]
        public ActionResult MoviesByReleaseDate(int year, int month)
        {
            return Content(year + " " + month);
        }

       
    }
}