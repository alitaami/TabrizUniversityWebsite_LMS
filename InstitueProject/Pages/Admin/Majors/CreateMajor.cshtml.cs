using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Institue.Core.Security;
using Institue.Core.Services.Interface;
using Institue.DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstitueProject.Pages.Admin.Majors
{
    [PermissionChecker(1)]

    public class CreateMajorModel : PageModel
    {
        IUserService _user;
        public CreateMajorModel(IUserService user)
        {
            _user = user;
        }
       [BindProperty]
        public Major Major { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _user.AddMajor(Major);
            return RedirectToPage("Index");
        }
    }
}
