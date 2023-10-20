using Microsoft.EntityFrameworkCore;
using My_Internship_Project.Models;

namespace My_Internship_Project.Services
{
    public class ArticleService
    {
        private readonly ApplicationDbContext _context;

        public ArticleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Article> GetArticles()
        {
            return _context.Articles.Include(a => a.Author).ToList();
        }

        public Article GetArticle(int id)
        {
            return _context.Articles.Include(a => a.Author).FirstOrDefault(a => a.Id == id);
        }

        public void CreateArticle(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public void UpdateArticle(int id, Article article)
        {
            if (id != article.Id)
            {
                throw new ArgumentException("Article ID mismatch");
            }
            _context.Entry(article).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteArticle(int id)
        {
            var article = _context.Articles.Find(id);
            if (article != null)
            {
                _context.Articles.Remove(article);
                _context.SaveChanges();
            }
        }
    }
}
