using System;
using System.Collections.Generic;
using My_Internship_Project.Models;

public interface ITagService
{
    List<Tag> GetTags();
    Tag GetTag(int id);
    void CreateTag(Tag tag);
    void UpdateTag(int id, Tag updatedTag);
    void DeleteTag(int id);
}
