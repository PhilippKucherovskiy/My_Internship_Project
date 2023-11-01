using Microsoft.EntityFrameworkCore;
using My_Internship_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace My_Internship_Project.Services
{
    public class TagService : ITagService
    {
        private readonly ApplicationDbContext _context;

        public TagService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Tag> GetTags()
        {
            return _context.Tags.ToList();
        }

        public Tag GetTag(int id)
        {
            return _context.Tags.Find(id);
        }

        public void CreateTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }

        public void UpdateTag(int id, Tag updatedTag)
        {
            if (id != updatedTag.Id)
            {
                throw new ArgumentException("Некорректный идентификатор тега.");
            }

            _context.Entry(updatedTag).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTag(int id)
        {
            var tag = _context.Tags.Find(id);
            if (tag == null)
            {
                throw new ArgumentException("Тег не найден.");
            }

            _context.Tags.Remove(tag);
            _context.SaveChanges();
        }
    }
}
