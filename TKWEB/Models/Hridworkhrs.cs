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
        public DateTime? Wrokdates { get; set; }
        public string Loginid { get; set; }
        public string Workid { get; set; }
        public decimal? Hrs { get; set; }
    }
}
