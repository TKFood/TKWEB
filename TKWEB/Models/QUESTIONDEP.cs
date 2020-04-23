using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TKWEB.Models
{
    public class QUESTIONDEP
    {   
        [Key]
        public string DEPID { get; set; }
        public string DEPNAME { get; set; }
    }
}
