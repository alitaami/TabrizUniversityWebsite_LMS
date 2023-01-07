using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Institue.DataLayer.Entities.Lesson
{
  public  class LessonPractice
    {
        [System.ComponentModel.DataAnnotations.Key]

        public int LessonPracticeId { get; set; }
        public int LessonId { get; set; }
        public int LessonDetailId { get; set; }

        public int UserId { get; set; }

        public string LessonPracticeFile { get; set; }

        public string LessonPracticeDescription { get; set; }

        public DateTime UploadDate { get; set; }

        #region relations

        [ForeignKey("LessonDetailId")]
        public LessonDetail LessonDetail { get; set; }

        #endregion
    }
}
