using Institue.DataLayer.Entities.Permission;
using Institue.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Institue.Core.Services.Interface
{
   public interface IPermissionService
    {
        #region
        void AddRolesToUser(List<int> SelectedRoles, int userid);
        List<Role> GetRoles();
        int addrole(Role role);
        void AddPermissionToRole(List<int> SelectedPermissions, int roleId);
        List<Permission> GetPermissions();
          void EditRolesUser(List<int> SelectedRoles, int userid);
         Role GetRoleById(int id);
        List<int> PermissionsRole(int roleid);
        void updateRole(Role role);
        void UpdatePermissionsRole(List<int> selecterpermissions, int roleId);
        public bool Checkpermission(int permissionId, string username);
       
    }
        #endregion
    }

