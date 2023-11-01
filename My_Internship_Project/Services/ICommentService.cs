using My_Internship_Project.Models;
using System;
using System.Collections.Generic;

public interface ICommentService
{
    List<Comment> GetComments();
    Comment GetComment(int id);
    void CreateComment(Comment comment);
    void UpdateComment(int id, Comment comment);
    void DeleteComment(int id);
}
