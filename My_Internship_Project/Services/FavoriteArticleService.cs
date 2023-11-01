using Microsoft.EntityFrameworkCore;
using My_Internship_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_Internship_Project.Services
{
    public class FavoriteArticleService : IFavoriteArticleService
    {
        private readonly ApplicationDbContext _context;

        public FavoriteArticleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<FavoriteArticle> GetFavoriteArticles()
        {
            return _context.FavoriteArticles.ToList();
        }

        public FavoriteArticle GetFavoriteArticle(int id)
        {
            return _context.FavoriteArticles.Find(id);
        }

        public void CreateFavoriteArticle(FavoriteArticle favoriteArticle)
        {
            _context.FavoriteArticles.Add(favoriteArticle);
            _context.SaveChanges();
        }

        public void DeleteFavoriteArticle(int id)
        {
            var favoriteArticle = _context.FavoriteArticles.Find(id);
            if (favoriteArticle == null)
            {
                throw new ArgumentException("Избранная статья не найдена.");
            }

            _context.FavoriteArticles.Remove(favoriteArticle);
            _context.SaveChanges();
        }
    }
}

