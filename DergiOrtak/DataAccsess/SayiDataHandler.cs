using DergiOrtak.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DergiOrtak.DataAccsess
{
    public class SayiDataHandler
    {
        private DergiDbContext _dbContext;
        public SayiDataHandler(DergiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Sayi> Listele(int dergiId)
        {
            return _dbContext.Sayi
                .Where(x => x.DergiId == dergiId)
                .Include(x => x.Dergi)
                .OrderByDescending(x => x.YayinTarihi)
                .ToList();
        }
        public Sayi Getir(int id)
        {
            return _dbContext.Sayi
                .Include(x => x.Dergi)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
