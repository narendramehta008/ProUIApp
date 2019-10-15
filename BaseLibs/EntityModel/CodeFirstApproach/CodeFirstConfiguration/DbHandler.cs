using BaseLibs.Handlers.FileHandlers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BaseLibs.EntityModel.CodeFirstApproach.CodeFirstConfiguration
{
   public class DbHandler
    {
       private DbContext dbContext;
        public DbHandler(DbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public bool AddData<T>(T data) where T : class
        {
            try
            {
                dbContext.Set<T>().Add(data);
                dbContext.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool UpdateData<T>(T data) where T : class
        {
            try
            {
                dbContext.Entry(data).State = EntityState.Modified;
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
