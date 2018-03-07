using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = new Movie() { Name = "Lotr" };
            return View(movies);

        }
        [Route("movies/released/{year}/{month:regex(\\d{4})}")]
        public ActionResult MoviesByReleaseDate(int year, int month)
        {
            return Content(year + " " + month);
        }
    }
}