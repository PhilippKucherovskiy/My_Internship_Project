using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using My_Internship_Project.Services;
using System.Linq;
using System.Threading.Tasks;


public class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManager;

    public RoleService(RoleManager<Role> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<bool> CreateRoleAsync(Role role)
    {
        var result = await _roleManager.CreateAsync(role);
        return result.Succeeded;
    }

    public async Task<bool> UpdateRoleAsync(Role role)
    {
        var result = await _roleManager.UpdateAsync(role);
        return result.Succeeded;
    }

    public async Task<bool> DeleteRoleAsync(string roleId)
    {
        var role = await _roleManager.FindByIdAsync(roleId);
        if (role != null)
        {
            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }
        return false;
    }

    public async Task<Role> GetRoleByIdAsync(string roleId)
    {
        return await _roleManager.FindByIdAsync(roleId);
    }

    public async Task<Role> GetRoleByNameAsync(string roleName)
    {
        return await _roleManager.FindByNameAsync(roleName);
    }

    public async Task<IEnumerable<Role>> GetRolesAsync()
    {
        return await _roleManager.Roles.AsQueryable().ToListAsync();
    }

}