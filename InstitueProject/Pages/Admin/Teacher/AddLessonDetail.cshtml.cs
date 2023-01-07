using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Institue.Core.Security;
using Institue.Core.Services.Interface;
using Institue.DataLayer.Entities.Lesson;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstitueProject.Pages.Admin.Teacher
{
    [PermissionChecker(2)]

    public class AddLessonDetailModel : PageModel
    {
        ILessonService _lesson;
        IUserService _User;
        public AddLessonDetailModel(ILessonService lesson, IUserService user)
        {
            _lesson = lesson;
            _User = user;
        }
        [BindProperty]
        public LessonDetail l { get; set; }
        public void OnGet(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                int userid = _User.GetUserByUsername(User.Identity.Name).UserId;
                l = new LessonDetail();
                l.LessonId = id;
                l.UserId = userid;
            }

        }
        public IActionResult OnPost(IFormFile lessonpdf, IFormFile lessonpractice, IFormFile lessonproject, IFormFile lessonvideo)
        {
            if (!ModelState.IsValid )
                return Page();

            _lesson.AddLessonDetail(l, lessonpdf, lessonpractice, lessonproject, lessonvideo);
            return Redirect("/Admin/Teacher/LessonDetailsIndex/" + l.LessonId);
        }
    }
}
