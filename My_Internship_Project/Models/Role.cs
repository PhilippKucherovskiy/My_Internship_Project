using Microsoft.AspNetCore.Identity;
using My_Internship_Project.Models;

public class Role : IdentityRole
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public bool IsActive { get; set; }
    public int Priority { get; set; }

    public List<Permission> Permissions { get; set; }
}
