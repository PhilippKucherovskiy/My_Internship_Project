using My_Internship_Project.Models;
using System.Collections.Generic;

namespace My_Internship_Project.Services
{
    public interface IFavoriteArticleService
    {
        List<FavoriteArticle> GetFavoriteArticles();
        FavoriteArticle GetFavoriteArticle(int id);
        void CreateFavoriteArticle(FavoriteArticle favoriteArticle);
        void DeleteFavoriteArticle(int id);
    }
}

