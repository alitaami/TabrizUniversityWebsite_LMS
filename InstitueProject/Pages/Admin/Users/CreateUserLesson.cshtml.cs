using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Institue.Core.Security;
using Institue.Core.Services.Interface;
using Institue.DataLayer.Entities.Lesson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstitueProject.Pages.Admin.Users
{
    [PermissionChecker(1)]

    public class CreateUserLessonModel : PageModel
    {
        ILessonService _lesson;
        public CreateUserLessonModel (ILessonService lesson)
        {
            _lesson = lesson;

        }

        [BindProperty]
        public UserLesson  UserLesson { get; set; }
        public void OnGet(int id)
        {
          

            UserLesson = new UserLesson();
            UserLesson.UserId = id;
           int userMajorId = _lesson.GetMajorIdofUser(id);

            ViewData["Lessons"] = _lesson.GetLessonsforcreateuser(userMajorId);
           
        }
        public IActionResult OnPost(List<int> Selectedlesson )
        {
            if (!ModelState.IsValid)
            {


                ViewData["notfound"] = "s";
                return Page();
            }


            _lesson.EditLessonUsers(Selectedlesson, UserLesson.UserId);

             return Redirect("/Admin/Users/IndexUserLesson/" + UserLesson.UserId);
        }

    }
}
