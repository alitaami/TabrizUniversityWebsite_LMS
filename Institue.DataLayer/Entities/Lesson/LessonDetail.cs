using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Institue.DataLayer.Entities.Lesson
{
    public class LessonDetail
    {
        [Key]
        public int LessonDetailId { get; set; }
        public int LessonId { get; set; }

        public int UserId { get; set; }
        public string LessonLink { get; set; }
        public string LessonLinkDescription { get; set; }
        public string LessonPdfFile { get; set; }
        public string LessonPdfFileDescription { get; set; }
        public string LessonPracticeFile { get; set; }
        public string LessonPracticeFileDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}" )]
        public DateTime? LessonPracticeFileExpireDate { get; set; }
        public string LessonProjectFile { get; set; }
        public string LessonProjectFileDescription { get; set; }

        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd}" )]
        public DateTime? LessonProjectFileExpireDate { get; set; }
        public string LessonVideoFile { get; set; }
        public string LessonVideoFileDescription { get; set; }
        public string LessonAlert { get; set; }
        public bool IsDelete { get; set; }

        #region relation
        [ForeignKey("LessonId")]

        public Lesson Lesson { get; set; }

        [ForeignKey("UserId")]
        public User.User User { get; set; }


        public List<LessonPractice> LessonPractice { get; set; }
        public List<LessonProject> LessonProject { get; set; }

        #endregion
    }


}
