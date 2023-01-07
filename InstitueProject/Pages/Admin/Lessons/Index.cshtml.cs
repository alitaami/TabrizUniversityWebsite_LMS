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

    public class IndexModel : PageModel
    {
        private ILessonService _lesson;
        public IndexModel(ILessonService lesson)
        {
            _lesson = lesson;

        }
       public List<LessonMajors> lessonMajors { get; set; }
        public void OnGet()
        {
            lessonMajors = _lesson.GetLessons();
        }
    }
}
