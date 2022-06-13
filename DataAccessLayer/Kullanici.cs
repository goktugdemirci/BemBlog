using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Kullanici
    {
        public int ID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Eposta { get; set; }
        public string Sifre { get; set; }
        public DateTime UyelikTarihi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public bool IsDeleted { get; set; }
    }
}
