using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Institue.DataLayer.Entities.Lesson
{
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
 
        public string LessonTitle { get; set; }



        public bool IsExistOnThisYear { get; set; }

        public bool IsDelete { get; set; }
        #region realtion


        public List<LessonMajors> LessonMajors { get; set; }

        public List<UserLesson> UserLessons { get; set; }
        public List<LessonDetail> LessonDetails { get; set; }

        #endregion
    }
}
