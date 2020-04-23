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

        [DisplayName("部門")]
        [Required]
        public string DEP { get; set; }

        [DisplayName("問題1")]
        [Required]
        public string QUESTION1 { get; set; }

        [DisplayName("問題2")]
        [Required]
        public string QUESTION2 { get; set; }

        [DisplayName("問題3")]
        [Required]
        public string QUESTION3 { get; set; }

        [DisplayName("問題4")]
        [Required]
        public string QUESTION4 { get; set; }

        [DisplayName("問題5")]
        [Required]
        public string QUESTION5 { get; set; }

        [DisplayName("問題6")]
        [Required]
        public string QUESTION6 { get; set; }

        [DisplayName("問題7")]
        [Required]
        public string QUESTION7 { get; set; }

        [DisplayName("問題8")]
        [Required]
        public string QUESTION8 { get; set; }

        [DisplayName("問題9")]
        [Required]
        public string QUESTION9 { get; set; }

        [DisplayName("問題10")]
        [Required]
        public string QUESTION10 { get; set; }

        [DisplayName("問題11")]
        [Required]
        public string QUESTION11 { get; set; }
    }
}
