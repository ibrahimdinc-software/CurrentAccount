using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrentAccount.Models
{
    public class HesapFis
    {
        [Key]
        public int id { get; set; }
        public int cariHesapId { get; set; }

        public DateTime tarih { get; set; }
        public float alacak { get; set; }
        public float borc { get; set; }
        public float bakiye { get; set; }
    }

    public class HesapFisForm
    {
        public int cariHesapId { get; set; }
        public string alacakBorc { get; set; }
        public float tutar { get; set; }
    }
}
