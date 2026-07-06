using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace jobmanager.Model
{
    public class IsIlani
    {
        [Key]
        public int IsIlaniId { get; set; } // İş ilanı ID (PK)

        public string Baslik { get; set; } // İş başlığı

        public string Aciklama { get; set; } // Açıklama

        public decimal Maas { get; set; } // Maaş

        public string Sehir { get; set; } // Şehir

        public DateTime YayimlanmaTarihi { get; set; } = DateTime.Now; // Yayınlanma tarihi

        public DateTime SonBasvuruTarihi { get; set; } // Son başvuru tarihi

        // Foreign Key
        public int SirketId { get; set; }

        // Navigation Property
        public Sirket Sirket { get; set; }
    }
}
