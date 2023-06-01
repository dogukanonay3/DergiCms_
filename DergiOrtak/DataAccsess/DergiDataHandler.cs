using DergiOrtak.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DergiOrtak.DataAccsess
{
    public class DergiDataHandler
    {
        private  DergiDbContext _dbContext;
        public DergiDataHandler(DergiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Dergi> Listele()
        {
            return _dbContext.Dergi.Include(x => x.Kategori).ToList();
        }
        public Dergi Getir(int id)
        {
            return _dbContext.Dergi.Include(x => x.Kategori).FirstOrDefault(x => x.Id == id);
        }
    }
}
