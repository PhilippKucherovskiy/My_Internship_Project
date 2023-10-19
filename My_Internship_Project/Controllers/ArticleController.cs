using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using My_Internship_Project.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace My_Internship_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ArticleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Article
        [HttpGet]
        public IActionResult GetArticles()
        {
            var articles = _context.Articles.Include(a => a.Author).ToList();
            return Ok(articles);
        }

        // GET: api/Article/5
        [HttpGet("{id}")]
        public IActionResult GetArticle(int id)
        {
            var article = _context.Articles.Include(a => a.Author).FirstOrDefault(a => a.Id == id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }

        // POST: api/Article
        [HttpPost]
        public IActionResult CreateArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetArticle), new { id = article.Id }, article);
        }

        // PUT: api/Article/5
        [HttpPut("{id}")]
        public IActionResult UpdateArticle(int id, Article article)
        {
            if (id != article.Id)
            {
                return BadRequest();
            }
            _context.Entry(article).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Article/5
        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(int id)
        {
            var article = _context.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }
            _context.Articles.Remove(article);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
