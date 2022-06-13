using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Makale
    {
        public int ID { get; set; }
        public int KategoriID { get; set; }
        public int YoneticiID { get; set; }
        public string Baslik { get; set; }
        public string Ozet { get; set; }
        public string TamIcerik { get; set; }
        public string ThumbnailAdi { get; set; }
        public string TamResimAdi { get; set; }
        public DateTime YuklemeTarih { get; set; }
        public int Okundu { get; set; }
        public bool IsDeleted { get; set; }
    }
}
