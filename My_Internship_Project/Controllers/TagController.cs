using Microsoft.AspNetCore.Mvc;
using My_Internship_Project.Models;
using My_Internship_Project.Services;

[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly ITagService _tagService;

    public TagController(ITagService tagService)
    {
        _tagService = tagService;
    }

    [HttpGet]
    public IActionResult GetTags()
    {
        var tags = _tagService.GetTags();
        return Ok(tags);
    }

    [HttpGet("{id}")]
    public IActionResult GetTag(int id)
    {
        var tag = _tagService.GetTag(id);
        if (tag == null)
        {
            return NotFound();
        }
        return Ok(tag);
    }

    [HttpPost]
    public IActionResult CreateTag(Tag tag)
    {
        _tagService.CreateTag(tag);
        return CreatedAtAction(nameof(GetTag), new { id = tag.Id }, tag);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTag(int id, Tag tag)
    {
        if (id != tag.Id)
        {
            return BadRequest();
        }
        _tagService.UpdateTag(id, tag);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTag(int id)
    {
        try
        {
            _tagService.DeleteTag(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
