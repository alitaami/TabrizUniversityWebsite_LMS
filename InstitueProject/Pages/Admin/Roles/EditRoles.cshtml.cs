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

    public class EditRolesModel : PageModel
    {
        private IPermissionService _permission;
        public EditRolesModel(IPermissionService per)
        {

            _permission = per;
        }
        [BindProperty]
        public Institue.DataLayer.Entities.User.Role Role { get; set; }
        public void OnGet(int id)
        {
            Role = _permission.GetRoleById(id);
            ViewData["Permissions"] = _permission.GetPermissions();
            ViewData["SelectedPermissions"] = _permission.PermissionsRole(id);

        }
        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
            {
return Page();

            }
                


            _permission.updateRole(Role);

            _permission.UpdatePermissionsRole( SelectedPermission,Role.RoleId);

            return RedirectToPage("Index");
        }
    }
}
