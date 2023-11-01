using System.ComponentModel.DataAnnotations;

namespace My_Internship_Project.Models
{
    public class AssignRoleModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Role { get; set; }
    }

}
