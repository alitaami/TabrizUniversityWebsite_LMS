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

    public class EditLessonsModel : PageModel
    {
        ILessonService _lesson;
        IUserService _user;
        public EditLessonsModel (ILessonService lesson,IUserService user)
        {
            _lesson = lesson;
            _user = user;
        }
        [BindProperty]
        public Lesson Lesson { get; set; }
        public void OnGet(int id)
        {
            Lesson = _lesson.GetLessonByID(id);
            ViewData["Majors"] = _user.GetMajors();


        }
        public IActionResult OnPost(List<int> SelectedMajors)
        {
           

            if (!ModelState.IsValid)
                return Page();


            _lesson.UpdateLesson(Lesson);
            _lesson.EditLessonMajors(SelectedMajors, Lesson.LessonId);

            
            return RedirectToPage("Index");

        }
    }
}
