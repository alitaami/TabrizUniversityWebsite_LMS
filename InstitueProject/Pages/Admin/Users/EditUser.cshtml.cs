using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Institue.Core.Security;
using Institue.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstitueProject.Pages.Admin.Users
{
    [PermissionChecker(1)]

    public class EditUserModel : PageModel
    {
        private IUserService _user;
        private IPermissionService _Per;
        public EditUserModel(IUserService user, IPermissionService per)
        {
            _user = user;
            _Per = per;

        }
        [BindProperty]
        public Institue.Core.ViewModels.EditUsersViewModel EditUserViewModel { get; set; }

        public void OnGet(int id)
        {
            EditUserViewModel = _user.GetUserforShowInEditMode(id);
            var Major = _user.getMajorForManage(EditUserViewModel.UserMajors,EditUserViewModel.UserID);
            ViewData["Majors"] = new SelectList(Major, "Value", "Text",EditUserViewModel.UserMajors);
            ViewData["Roles"] = _Per.GetRoles();
        }

        public IActionResult OnPost(List<int> SelectedRoles, List<int> SelectedMajors)
        {
            if (!ModelState.IsValid)
            {

                ViewData["notfound"] = "s";
                EditUserViewModel = _user.GetUserforShowInEditMode(EditUserViewModel.UserID);
                var Major = _user.getMajorForManage(EditUserViewModel.UserMajors, EditUserViewModel.UserID);
                ViewData["Majors"] = new SelectList(Major, "Value", "Text", EditUserViewModel.UserMajors);
                ViewData["Roles"] = _Per.GetRoles();
                return Page();
            }

        
            _user.EditUserForAdmin(EditUserViewModel);
            
            _Per.EditRolesUser(SelectedRoles, EditUserViewModel.UserID);
            _user.EditMajorsToUser(SelectedMajors, EditUserViewModel.UserID);

            if(EditUserViewModel.IsTeacher)
            return RedirectToPage("/Admin/Users/IndexTeacher");
            else
            {
                return RedirectToPage("/Admin/Users/Index");

            }
        }

    }
}
