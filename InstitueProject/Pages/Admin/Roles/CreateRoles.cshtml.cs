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

    public class CreateRolesModel : PageModel
    {
        private IPermissionService _permission;
        public CreateRolesModel(IPermissionService per)
        {

            _permission = per;
        }
        [BindProperty]
        public Institue.DataLayer.Entities.User.Role Role { get; set; }
        public void OnGet()
        {
            ViewData["Permissions"] = _permission.GetPermissions();
        }
        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
                return Page();


            Role.IsDelete = false;
            int roleId = _permission.addrole(Role);
            //TODO Add permissions
            _permission.AddPermissionToRole(SelectedPermission,roleId );
            return RedirectToPage("Index");
        }
    }
}
