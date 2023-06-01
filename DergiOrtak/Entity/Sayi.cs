using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DergiOrtak.Entity
{
    public class Sayi : EntityBase
    {
        public int DergiId { get; set; }
        public Dergi Dergi { get; set; }

        public int No { get; set; }
        public DateTime YayinTarihi { get; set; }
    }
}
