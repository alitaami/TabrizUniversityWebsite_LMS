using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Institue.Core.Security;
using Institue.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstitueProject.Pages.Admin.Users
{
    [PermissionChecker(1)]

    public class IndexTeacherModel : PageModel
    {
        IUserService _user;
        public IndexTeacherModel(IUserService user)
        {
            _user = user;
        }
        public Institue.Core.ViewModels.USerForAdminViewModel user { get; set; }
        public void OnGet(int pageid = 1, string TNum = "", string lastname = "")
        {
            user = _user.GetTeachers(pageid, TNum, lastname);
        }
    }
}
