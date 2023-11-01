using Microsoft.AspNetCore.Mvc;
using My_Internship_Project.Models;
using System;
using My_Internship_Project.Services;

namespace My_Internship_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public IActionResult GetComments()
        {
            var comments = _commentService.GetComments();
            return Ok(comments);
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var comment = _commentService.GetComment(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _commentService.CreateComment(comment);
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComment(int id, Comment comment)
        {
            try
            {
                _commentService.UpdateComment(id, comment);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int id)
        {
            _commentService.DeleteComment(id);
            return NoContent();
        }
    }
}