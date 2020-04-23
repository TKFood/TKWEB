using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TKWEB.Models
{
    public partial class QUESTIONNAIRES
    {
        public Guid ID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DisplayName("日期")]
        [Required]
        public DateTime? DATES { get; set; }

        [DisplayName("工號")]
        [Required]
        public string NO { get; set; }

        [DisplayName("姓名")]
        [Required]
        public string NAME { get; set; }

        [DisplayName("問題1")]
        [Required]
        public string QUESTION1 { get; set; }

        [DisplayName("問題2")]
        [Required]
        public string QUESTION2 { get; set; }
    }
}
