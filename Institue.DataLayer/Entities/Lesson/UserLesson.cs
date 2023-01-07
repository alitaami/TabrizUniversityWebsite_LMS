using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Institue.DataLayer.Entities.Lesson
{
  public  class UserLesson
    {
        [Key]
        public int UL_id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]

        public int LessonId { get; set; }
        #region Relation
        [ForeignKey("UserId")]
        public User.User User { get; set; }
        [ForeignKey("LessonId")]
        public Lesson  Lesson { get; set; }

        #endregion

    }
}
