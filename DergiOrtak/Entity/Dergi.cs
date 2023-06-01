using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DergiOrtak.Entity
{
    public class Dergi : EntityBase
    {
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }

        public string Adi { get; set; }
        public string Aciklama { get; set; }
    }
}
