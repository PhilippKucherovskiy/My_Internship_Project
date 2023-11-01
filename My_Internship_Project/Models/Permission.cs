namespace My_Internship_Project.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public bool CanView { get; set; } 
        public bool CanEdit { get; set; } 
        public bool CanDelete { get; set; } 
        public bool CanCreate { get; set; }

        public List<Role> Roles { get; set; }

    }

}
