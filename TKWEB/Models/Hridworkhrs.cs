using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TKWEB.Models
{
    public partial class Hridworkhrs
    {
        public Guid Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}",ApplyFormatInEditMode = true)]
        [DisplayName("日期")]
        [Required]
        public DateTime? Wrokdates { get; set; }

        [DisplayName("工號")]
        [Required]
        public string Loginid { get; set; }
        [DisplayName("工作項目")]
        [Required]
        public string Workid { get; set; }
        [DisplayName("工時")]
        [Required]
        public decimal? Hrs { get; set; }
    }
}
