using DergiOrtak.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DergiOrtak.DataAccsess
{
    public class MakaleDataHandler
    {
        private DergiDbContext _dbContext;
        public MakaleDataHandler(DergiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Makale> Listele(int sayiId)
        {
            return _dbContext.Makale
                .Where(x => x.SayiId == sayiId)
                .ToList(); 
        }
        public Makale Getir(int id)
        {
          return _dbContext.Makale
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
