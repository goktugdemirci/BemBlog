using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yorum
    {
        public int ID { get; set; }
        public int MakaleID { get; set; }
        public int KullaniciID { get; set; }
        public string YorumIcerik { get; set; }
        public DateTime YorumTarihi { get; set; }
        public bool IsDeleted { get; set; }
    }
}
