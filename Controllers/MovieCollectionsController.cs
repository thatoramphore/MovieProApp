using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieProApp.Data;
using MovieProApp.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProApp.Controllers
{
    public class MovieCollectionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieCollectionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            //if id is null, then default the id to that of the ALL collection
            id ??= (await _context.Collection.FirstOrDefaultAsync(c => c.Name.ToUpper() == "ALL")).Id;

            //dropdown list of the collections
            ViewData["CollectionId"] = new SelectList(_context.Collection, "Id", "Name", id);

            //select and store all movie Id in allMovieIds from the DB
            var allMovieIds = await _context.Movie.Select(m => m.Id).ToListAsync();

            var movieIdsInCollection = await _context.MovieCollection
                                        .Where(m => m.CollectionId == id)
                                        .OrderBy(m => m.Order)
                                        .Select(m => m.MovieId)
                                        .ToListAsync();

            //a collection of all MOVIEIDS not in the collection
            var movieIdsNotInCollection = allMovieIds.Except(movieIdsInCollection);

            //add records to movie in collection based on id
            var moviesInCollection = new List<Movie>();
            movieIdsInCollection.ForEach(movieId => moviesInCollection.Add(_context.Movie.Find(movieId)));

            //allow user to manage and view movies in a collection
            ViewData["IdsInCollection"] = new MultiSelectList(moviesInCollection, "Id", "Title");

            //a collection of MOVIES not in the collection
            var moviesNotInCollection = await _context.Movie.AsNoTracking().Where(m => movieIdsNotInCollection.Contains(m.Id)).ToListAsync();
            ViewData["IdsNotInCollection"] = new MultiSelectList(moviesNotInCollection, "Id", "Title");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(int id, List<int> idsInCollection)
        {
            //get rid of old movies in the collection
            var oldRecords = _context.MovieCollection.Where(c => c.CollectionId == id);
            _context.MovieCollection.RemoveRange(oldRecords);       //delete records
            await _context.SaveChangesAsync();              //update the DB


            //add new movies from incoming list of movies
            if (idsInCollection != null)
            {
                int index = 1;
                idsInCollection.ForEach(movieId =>
                {
                    _context.Add(new MovieCollection()
                    {
                        CollectionId = id,
                        MovieId = movieId,
                        Order = index++
                    });
                });

                await _context.SaveChangesAsync();
            }
            //redirect user to new arrangement of movies
            return RedirectToAction(nameof(Index), new { id });
        }
    }
}
