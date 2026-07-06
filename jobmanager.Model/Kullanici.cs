using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace jobmanager.Model
{
    public class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }

        public string AdSoyad { get; set; } 

        public string Eposta { get; set; } 

        public string Sifre { get; set; } 

        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
        public ICollection<Sirket> Sirketler { get; set; }

    }
}
