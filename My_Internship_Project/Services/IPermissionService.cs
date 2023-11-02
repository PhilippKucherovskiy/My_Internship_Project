using My_Internship_Project.Models;

namespace My_Internship_Project.Services
{
    public interface IPermissionService
    {
        Task<bool> AssignPermissionToRoleAsync(Role role, Permission permission);
        Task<bool> RemovePermissionFromRoleAsync(Role role, Permission permission);
        Task<IEnumerable<Permission>> GetPermissionsForRoleAsync(Role role);
    }
}
