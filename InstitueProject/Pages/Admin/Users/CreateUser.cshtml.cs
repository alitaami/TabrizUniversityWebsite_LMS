using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Institue.Core.Security;
using Institue.Core.Services.Interface;
using Institue.Core.ViewModels;
using Institue.DataLayer.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TopLearnProject2022.Pages.Admin.Users
{
    [PermissionChecker(1)]

    public class CreateUserModel : PageModel
    {
        private IPermissionService _permission;
        private IUserService _user;
        ILessonService _lesson;
        public CreateUserModel(IPermissionService permission,IUserService user,ILessonService lesson)
        {
            _lesson = lesson;
            _permission = permission;
            _user = user;

        }
        //چون قرار است تغییراتی در مقدار پراپرتی اعمال شود باید بایندپراپرتی باشد
        [BindProperty]
        public CreateUsersViewModel U { get; set; }
        public void OnGet()
        {
            ViewData["Roles"] = _permission.GetRoles();
             var Majors = _user.GetMajors();
            ViewData["Majors"] = Majors;


            if (Majors != null)
            {
                ViewData["Majors"] = new SelectList(Majors, "MajorId", "MajorTitle");

            }

        }
        public IActionResult OnPost(List<int> SelectedMajors, List<int>SelectedRoles)
        {
            if (!ModelState.IsValid  )
            {


                ViewData["notfound"] = "s";
                return Page();
            }
            if (U.homenumber.Trim().Length>11 || U.phonenumber.Trim().Length > 11 )
            {


                ViewData["errorfornum"] = "s";
                return Page();
            }

            if (_user.IsUserExist(U.studentnumber, U.Teachernumber, U.firstname + "" + U.Lastname))
            {
                ViewData["Exists"] = "s";
                return Page();
            }
            int userid = _user.AddUserFromAdmin(U);
            
            _permission.AddRolesToUser(SelectedRoles, userid);
            _user.AddMajorToUser(SelectedMajors, userid);
            return Redirect("/Admin/Users");
        }
    }
}
