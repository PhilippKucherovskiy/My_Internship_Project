using Microsoft.AspNetCore.Mvc;
using My_Internship_Project.Models;
using System.Linq;

namespace My_Internship_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteArticleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FavoriteArticleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FavoriteArticle
        [HttpGet]
        public IActionResult GetFavoriteArticles()
        {
            var favoriteArticles = _context.FavoriteArticles.ToList();
            return Ok(favoriteArticles);
        }

        // GET: api/FavoriteArticle/5
        [HttpGet("{id}")]
        public IActionResult GetFavoriteArticle(int id)
        {
            var favoriteArticle = _context.FavoriteArticles.Find(id);
            if (favoriteArticle == null)
            {
                return NotFound();
            }
            return Ok(favoriteArticle);
        }

        // POST: api/FavoriteArticle
        [HttpPost]
        public IActionResult CreateFavoriteArticle(FavoriteArticle favoriteArticle)
        {
            _context.FavoriteArticles.Add(favoriteArticle);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetFavoriteArticle), new { id = favoriteArticle.UserId }, favoriteArticle);
        }

        // DELETE: api/FavoriteArticle/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFavoriteArticle(int id)
        {
            var favoriteArticle = _context.FavoriteArticles.Find(id);
            if (favoriteArticle == null)
            {
                return NotFound();
            }
            _context.FavoriteArticles.Remove(favoriteArticle);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
