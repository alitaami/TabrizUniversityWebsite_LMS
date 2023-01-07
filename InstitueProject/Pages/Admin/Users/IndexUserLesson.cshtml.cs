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

    public class IndexUserLessonModel : PageModel
    {
        ILessonService _lesson;
        public IndexUserLessonModel(ILessonService lesson)
        {
            _lesson = lesson;

        }

        [BindProperty]
        public List<UserLesson> UserLesson { get; set; }
        public void OnGet(int id)
        {
            ViewData["UserId"] = id;
            UserLesson = _lesson.GetLessonsOfUser(id);
        }
    }
}
