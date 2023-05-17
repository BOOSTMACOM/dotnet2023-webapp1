using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Domain.Cmd;
using WebApplication1.Domain.Services;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {

        private readonly MovieService _movieService;

        public MoviesController(MovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: Movies
        public IActionResult Index()
        {
            //return _context.Movie != null ? 
            //            View(await _context.Movie.ToListAsync()) :
            //            Problem("Entity set 'WebApplication1Context.Movie'  is null.");

            return View(_movieService.GetMovieItemDTOs());

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CreateMovieCmd());
        }

        [HttpPost]
		public IActionResult CreatePost(CreateMovieCmd cmd)
		{
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Vérifiez les champs !");

                _movieService.CreateNewMovie(cmd);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View("Create", cmd);
            }
        }

        public IActionResult Edit(int id)
        {
            try
            {
                var cmd = _movieService.GetEditMovieCmd(id);
                return View(cmd);
            }
            catch(Exception e) 
            {
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult EditPost(EditMovieCmd cmd)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("Vérifiez les champs du formulaire !");

                _movieService.UpdateMovie(cmd);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View("Edit",cmd);
            }
        }

    }
}
