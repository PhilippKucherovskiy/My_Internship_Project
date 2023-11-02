using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using My_Internship_Project.Models;

namespace My_Internship_Project.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly ApplicationDbContext _context;

        public PermissionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AssignPermissionToRoleAsync(Role role, Permission permission)
        {
            var rolePermission = new RolePermission
            {
                RoleId = role.Id,
                PermissionId = permission.Id
            };
            _context.RolePermissions.Add(rolePermission);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemovePermissionFromRoleAsync(Role role, Permission permission)
        {
            var rolePermission = _context.RolePermissions.FirstOrDefault(rp => rp.RoleId == role.Id && rp.PermissionId == permission.Id);
            if (rolePermission != null)
            {
                _context.RolePermissions.Remove(rolePermission);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Permission>> GetPermissionsForRoleAsync(Role role)
        {
            var permissionIds = _context.RolePermissions
                .Where(rp => rp.RoleId == role.Id)
                .Select(rp => rp.PermissionId);
            return await _context.Permissions
                .Where(p => permissionIds.Contains(p.Id))
                .ToListAsync();
        }
    }
}
