using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Internship_Project.Models;
using My_Internship_Project.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace My_Internship_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public IActionResult GetArticles()
        {
            var articles = _articleService.GetArticles();
            return Ok(articles);
        }

        [HttpGet("{id}")]
        public IActionResult GetArticle(int id)
        {
            var article = _articleService.GetArticle(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        [HttpPost]
        public IActionResult CreateArticle(Article article)
        {
            _articleService.CreateArticle(article);
            return CreatedAtAction(nameof(GetArticle), new { id = article.Id }, article);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateArticle(int id, Article article)
        {
            try
            {
                _articleService.UpdateArticle(id, article);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(int id)
        {
            _articleService.DeleteArticle(id);
            return NoContent();
        }
    }
}