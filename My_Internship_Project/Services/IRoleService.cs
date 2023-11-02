namespace My_Internship_Project.Services
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(Role role);
        Task<bool> UpdateRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(string roleId);
        Task<Role> GetRoleByIdAsync(string roleId);
        Task<Role> GetRoleByNameAsync(string roleName);
        Task<IEnumerable<Role>> GetRolesAsync();
    }
}
