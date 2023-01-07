using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Institue.DataLayer.Entities.Lesson
{
  public  class LessonProject
    {
        [Key]
        public int LessonProjectId { get; set; }
        public int LessonId { get; set; }
        public int LessonDetailId { get; set; }

        public int UserId { get; set; }

        public string LessonProjectFile { get; set; }

        public string LessonProjectDescription { get; set; }

        public DateTime UploadDate { get; set; }

        #region relations

        [ForeignKey("LessonDetailId")]
        public LessonDetail LessonDetail { get; set; }

        #endregion

    }
}
