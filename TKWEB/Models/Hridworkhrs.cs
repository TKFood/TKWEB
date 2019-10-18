using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TKWEB.Models
{
    public partial class Hridworkhrs
    {
        public Guid Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}",ApplyFormatInEditMode = true)]
        [Required]
        public DateTime? Wrokdates { get; set; }
        [Required]
        public string Loginid { get; set; }
        [Required]
        public string Workid { get; set; }
        [Required]
        public decimal? Hrs { get; set; }
    }
}
