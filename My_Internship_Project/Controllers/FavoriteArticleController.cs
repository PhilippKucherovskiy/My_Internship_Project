using Microsoft.AspNetCore.Mvc;
using My_Internship_Project.Models;
using System.Linq;
using My_Internship_Project.Services;

namespace My_Internship_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteArticleController : ControllerBase
    {
        private readonly IFavoriteArticleService _favoriteArticleService;

        public FavoriteArticleController(IFavoriteArticleService favoriteArticleService)
        {
            _favoriteArticleService = favoriteArticleService;
        }

        // GET: api/FavoriteArticle
        [HttpGet]
        public IActionResult GetFavoriteArticles()
        {
            var favoriteArticles = _favoriteArticleService.GetFavoriteArticles();
            return Ok(favoriteArticles);
        }

        // GET: api/FavoriteArticle/5
        [HttpGet("{id}")]
        public IActionResult GetFavoriteArticle(int id)
        {
            var favoriteArticle = _favoriteArticleService.GetFavoriteArticle(id);
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
            _favoriteArticleService.CreateFavoriteArticle(favoriteArticle);
            return CreatedAtAction(nameof(GetFavoriteArticle), new { id = favoriteArticle.UserId }, favoriteArticle);
        }

        // DELETE: api/FavoriteArticle/5
        [HttpDelete("{id}")]
        public IActionResult DeleteFavoriteArticle(int id)
        {
            _favoriteArticleService.DeleteFavoriteArticle(id);
            return NoContent();
        }
    }
}
