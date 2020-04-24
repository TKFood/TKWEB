using System;
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

        [DisplayName("請問24小時內，您與您同住的家屬/室友否出現以下微狀(複選)?")]
        [Required]
        public string QUESTION1 { get; set; }

        [DisplayName("承上題，如有症狀請簡短說明何時、何地、何人")]
        //[Required]
        public string QUESTION2 { get; set; }

        [DisplayName("請問24小時內您與您的同住的家屬/室友是否從其他國家入境台灣？")]
        [Required]
        public string QUESTION3 { get; set; }

        [DisplayName("承上題，簡短說明何時、何地、何人、班次?")]
        //[Required]
        public string QUESTION4 { get; set; }

        [DisplayName("請問24小時內您與您的同住的家屬/室友是否曾與已確診/疑似/正在接受檢驗之新型冠狀病毒肺炎病患有接觸？")]
        [Required]
        public string QUESTION5 { get; set; }

        [DisplayName("承上題，簡短說明何時接觸、何地接觸、何人接觸?")]
        //[Required]
        public string QUESTION6 { get; set; }

        [DisplayName("請問24小時內您與您的同住的家屬/室友是否曾前往非閉密空間但人潮擁擠的公共場所(無適當社交距離1M)，如旅遊地區、夜市、風景地區、寺廟等？")]
        [Required]
        public string QUESTION7 { get; set; }

        [DisplayName("承上題，簡短說明何時、何地、何人、共約幾人")]
        //[Required]
        public string QUESTION8 { get; set; }

        [DisplayName("請問24小時內您與您的同住的家屬/室友是否曾搭乘大眾交通運輸工具（公車、台鐵、高鐵、捷運、渡輪、客運、遊覽車…）")]
        [Required]
        public string QUESTION9 { get; set; }

        [DisplayName("承上題，簡短說明何時、何地、何人、何種交通工具、班次?")]
        //[Required]
        public string QUESTION10 { get; set; }

        [DisplayName("其他想告知的事項")]
        //[Required]
        public string QUESTION11 { get; set; }

      
    }
}
