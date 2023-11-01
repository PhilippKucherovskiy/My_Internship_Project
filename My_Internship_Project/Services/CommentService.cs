using Microsoft.EntityFrameworkCore;
using My_Internship_Project;
using My_Internship_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class CommentService : ICommentService
{
    private readonly ApplicationDbContext _context;

    public CommentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Comment> GetComments()
    {
        return _context.Comments.ToList();
    }

    public Comment GetComment(int id)
    {
        return _context.Comments.Find(id);
    }

    public void CreateComment(Comment comment)
    {
        _context.Comments.Add(comment);
        _context.SaveChanges();
    }

    public void UpdateComment(int id, Comment comment)
    {
        if (id != comment.Id)
        {
            throw new ArgumentException("Comment ID mismatch");
        }
        _context.Entry(comment).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void DeleteComment(int id)
    {
        var comment = _context.Comments.Find(id);
        if (comment != null)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }
    }
}