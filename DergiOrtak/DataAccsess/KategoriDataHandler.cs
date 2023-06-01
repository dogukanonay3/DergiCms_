using DergiOrtak.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DergiOrtak.DataAccsess
{
    public class KategoriDataHandler
    {
        private DergiDbContext _dbContext;
        public KategoriDataHandler(DergiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Kategori> Listele()
        {
            return _dbContext.Kategori.ToList();
        } 

    }
}
