using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Institue.Core.Security;
using Institue.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstitueProject.Pages.Admin.Roles
{
    [PermissionChecker(1)]

    public class IndexModel : PageModel
    {
        private IPermissionService _permission;
        public IndexModel(IPermissionService permission)
        {
            _permission = permission;

        }
        public List<Institue.DataLayer.Entities.User.Role> RolesList { get; set; }
        public void OnGet()
        {
            RolesList = _permission.GetRoles();
        }
    }
}