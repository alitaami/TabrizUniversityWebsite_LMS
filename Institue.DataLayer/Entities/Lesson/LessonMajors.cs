using Institue.DataLayer.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Institue.DataLayer.Entities.Lesson
{
  public  class LessonMajors
    {
        [Key]
       public int LM_Id { get; set; }
        public int LessonId { get; set; }
        public int MajorId { get; set; }

        #region relations
        public Lesson Lesson { get; set; }
        public Major Major { get; set; }
        #endregion
    }
}
