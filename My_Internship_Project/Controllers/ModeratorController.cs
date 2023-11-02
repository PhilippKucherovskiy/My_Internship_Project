// ModeratorController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using My_Internship_Project.Models;

[Authorize(Roles = "Moderator")]
[Route("api/[controller]")]
[ApiController]
public class ModeratorController : ControllerBase
{
    private readonly IArticleService _articleService;
    private readonly ICommentService _commentService;

    public ModeratorController(IArticleService articleService, ICommentService commentService)
    {
        _articleService = articleService;
        _commentService = commentService;
    }

    [Authorize(Roles = "Moderator")]
    [HttpPost("create-article")]
    public IActionResult CreateArticle(Article article)
    {
        _articleService.CreateArticle(article);
        return CreatedAtAction(nameof(ArticleService.GetArticle), new { id = article.Id }, article);
    }

    [Authorize(Roles = "Moderator")]
    [HttpPut("update-article/{id}")]
    public IActionResult UpdateArticle(int id, Article article)
    {
        if (id != article.Id)
        {
            return BadRequest();
        }
        _articleService.UpdateArticle(id, article);
        return NoContent();
    }

    [Authorize(Roles = "Moderator")]
    [HttpDelete("delete-article/{id}")]
    public IActionResult DeleteArticle(int id)
    {
        _articleService.DeleteArticle(id);
        return NoContent();
    }

}
