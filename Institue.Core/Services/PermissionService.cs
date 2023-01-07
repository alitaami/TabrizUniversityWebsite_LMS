using Institue.Core.Services.Interface;
using Institue.DataLayer.Entities.Permission;
using Institue.DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Institue.Core.Services
{
    public class PermissionService : IPermissionService
    {
        DataLayer.Context.InstitueContext _context;
        public PermissionService(DataLayer.Context.InstitueContext context)
        {
            _context = context;

        }

        public void AddPermissionToRole(List<int> SelectedPermissions, int roleId)
        {
            foreach (int p in SelectedPermissions)
            {
                _context.RolePermissions.Add(new RolePermission()
                {
                    RoleId = roleId,
                    PermissionId = p

                });
                _context.SaveChanges();

            }
        }
        public bool Checkpermission(int permissionId, string username)
        {

            int userid = _context.Users.Single(u => u.UserName == username).UserId;
            List<int> UserRoles = _context.UserRoles.Where(u => u.UserId == userid).Select(r => r.RoleId).ToList();
            if (UserRoles == null)
            {
                return false;
            }
            List<int> RolesPermission = _context.RolePermissions
                .Where(r => r.PermissionId == permissionId)
                .Select(r => r.RoleId).ToList();

            return RolesPermission.Any(p => UserRoles.Contains(p));

        }
        public int addrole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role.RoleId;
        }

        public void AddRolesToUser(List<int> SelectedRoles, int userid)
        {
            foreach (var roleid in SelectedRoles)
            {
                _context.UserRoles.Add(new UserRole
                {
                    RoleId = roleid,
                    UserId = userid
                });
                _context.SaveChanges();
            }
        }

        public void EditRolesUser(List<int> SelectedRoles, int userid)
        {
            //delete roles
            _context.UserRoles.Where(u => u.UserId == userid).ToList().ForEach(u => _context.UserRoles.Remove(u));
            //add new roles
            AddRolesToUser(SelectedRoles, userid);

        }

        public List<Permission> GetPermissions()
        {
            return _context.Permissions.ToList();
        }

        public Role GetRoleById(int id)
        {
            return _context.Roles.Find(id);
        }

        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public List<int> PermissionsRole(int roleid)
        {
            return _context.RolePermissions.Where(u => u.RoleId == roleid)
                            .Select(u => u.PermissionId).ToList();
        }

        public void UpdatePermissionsRole(List<int> selecterpermissions, int roleId)
        {
            _context.RolePermissions.Where(u => u.RoleId == roleId).ToList()
                            .ForEach(u => _context.RolePermissions.Remove(u));

            AddPermissionToRole(selecterpermissions, roleId);

        }

        public void updateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        
    }
}
