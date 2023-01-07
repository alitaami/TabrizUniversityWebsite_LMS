using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Institue.Core.Security;
using Institue.Core.Services.Interface;
using Institue.DataLayer.Entities.Lesson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstitueProject.Pages.Admin.Teacher
{
    [PermissionChecker(2)]

    public class IndexModel : PageModel
    {
        ILessonService _lesson;
        IUserService _user;
        public IndexModel(ILessonService lesson, IUserService user)
        {
            _lesson = lesson;
            _user = user;
        }

        [BindProperty]
        public List<UserLesson> UserLesson { get; set; }
        public  IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = _user.GetUserByUsername(User.Identity.Name);
                if (user != null)
                {
                    int userid = user.UserId;
                    UserLesson = _lesson.GetLessonsOfUser(userid);

                }
            }
            else
            {
 return BadRequest();
            }
            return Page();

        }
    }
}

