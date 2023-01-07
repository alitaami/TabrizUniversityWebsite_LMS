using Institue.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Institue.DataLayer.Entities.Permission
{
    public class RolePermission
    {
        [Key]
        public int RP_Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        #region relations
        public Role Role { get; set; }
        public Entities.Permission.Permission Permission { get; set; }
        #endregion
    }

}
