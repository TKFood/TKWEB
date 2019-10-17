using System;
using System.Collections.Generic;

namespace TKWEB.Models
{
    public partial class Hridworkhrs
    {
        public Guid Id { get; set; }
        public DateTime? Wrokdates { get; set; }
        public string Loginid { get; set; }
        public string Workid { get; set; }
        public decimal? Hrs { get; set; }
    }
}
