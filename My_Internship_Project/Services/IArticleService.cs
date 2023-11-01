using My_Internship_Project.Models;
using System;
using System.Collections.Generic;

public interface IArticleService
{
    List<Article> GetArticles();
    Article GetArticle(int id);
    void CreateArticle(Article article);
    void UpdateArticle(int id, Article article);
    void DeleteArticle(int id);
}