using DergiOrtak.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DergiOrtak.DataAccsess
{
    public abstract class DataHandlerBase
    {
        private DergiDbContext _dbContext;
        public DataHandlerBase(DergiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Insert(EntityBase model)
        {
            _dbContext.Add(model);
            _dbContext.SaveChanges();
        }
        public void Update(EntityBase model)
        {
            _dbContext.Update(model);
            _dbContext.SaveChanges();
        }
        public void Delete(EntityBase model)
        {
            _dbContext.Remove(model);
            _dbContext.SaveChanges();
        }
    }
}
