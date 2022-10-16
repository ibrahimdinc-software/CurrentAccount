using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrentAccount.Models
{
    public class CariHesap
    {
        [Key]
        public int id { get; set; }
        public string ad { get; set; }
    }
}
