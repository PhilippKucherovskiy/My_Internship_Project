using Microsoft.AspNetCore.Mvc;
using My_Internship_Project.Models;
using System.Linq;

namespace My_Internship_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TagController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tag
        [HttpGet]
        public IActionResult GetTags()
        {
            var tags = _context.Tags.ToList();
            return Ok(tags);
        }

        // GET: api/Tag/5
        [HttpGet("{id}")]
        public IActionResult GetTag(int id)
        {
            var tag = _context.Tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(tag);
        }

        // POST: api/Tag
        [HttpPost]
        public IActionResult CreateTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTag), new { id = tag.Id }, tag);
        }

        // PUT: api/Tag/5
        [HttpPut("{id}")]
        public IActionResult UpdateTag(int id, Tag tag)
        {
            if (id != tag.Id)
            {
                return BadRequest();
            }
            _context.Entry(tag).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Tag/5
        [HttpDelete("{id}")]
        public IActionResult DeleteTag(int id)
        {
            var tag = _context.Tags.Find(id);
            if (tag == null)
            {
                return NotFound();
            }
            _context.Tags.Remove(tag);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
