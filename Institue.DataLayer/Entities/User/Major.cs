using Institue.DataLayer.Entities.Lesson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Institue.DataLayer.Entities.User
{
    public class Major
    {
        [Key]
        public int MajorId { get; set; }
        [Required]
        public string MajorTitle { get; set; }
        public string description { get; set; }

        public bool IsDelete { get; set; }
        public List<LessonMajors> LessonMajors { get; set; }

        public List<UserMajors> UserMajors { get; set; }

    }
}
