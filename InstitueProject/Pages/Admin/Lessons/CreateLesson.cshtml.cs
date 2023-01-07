using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Institue.Core.Security;
using Institue.Core.Services.Interface;
using Institue.DataLayer.Entities.Lesson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstitueProject.Pages.Admin.Lessons
{
    [PermissionChecker(1)]
    public class CreateLessonModel : PageModel
    {
        ILessonService _lesson ;
        IUserService _user;
        public CreateLessonModel(ILessonService lessonService,IUserService user)
        {
            _user = user;
            _lesson = lessonService;
        }
        [BindProperty]
        public Lesson Lesson { get; set; }
        public void OnGet()
        {
            ViewData["Majors"] = _user.GetMajors();
        }
        public IActionResult OnPost(List<int> SelectedMajors)
        {
            Lesson.IsDelete = false;

            if (!ModelState.IsValid)
                return Page();
            
            int lessonid = _lesson.AddLesson(Lesson);

            _lesson.AddMajortoLesson(SelectedMajors, lessonid);
            return RedirectToPage("Index");

        }
    }
}
