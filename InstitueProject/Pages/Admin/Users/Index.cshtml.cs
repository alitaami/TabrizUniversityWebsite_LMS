using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Institue.Core.Security;
using Institue.Core.Services.Interface;
using Institue.DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstitueProject.Pages.Admin.Users
{
    [PermissionChecker(1)]

    public class IndexModel : PageModel
    {
        IUserService _user;
        public IndexModel (IUserService user)
        {
            _user = user;
        }
        public Institue.Core.ViewModels.USerForAdminViewModel user { get; set; }
        public void OnGet(int pageid = 1, string StNumber = "", string lastname = "")
        {
            user = _user.GetUsers(pageid, StNumber, lastname);
        }
    }
}
