using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace jobmanager.Model
{
    public class Sirket
    {
        [Key]
        public int SirketId { get; set; } 

        public string SirketAdi { get; set; }

        public string Aciklama { get; set; } // Açıklama

        public string Sehir { get; set; } // Şehir

        public string Eposta { get; set; } // E-posta

        public string Telefon { get; set; } // Telefon

        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now; // Oluşturulma tarihi

        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }
        public List<IsIlani> IsIlanlari { get; set; }
    }
}

