using BaseLibs.Handlers.FileHandlers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.EntityModel.CodeFirstApproach.CodeFirstConfiguration
{
   public class DbContextMapper
    {
        public string DbConnectionString = ConstantVariables.DBPath;
        public DbContext GetDBContext(string dbconnectionString = null)
        {
            if (dbconnectionString == null)
                dbconnectionString = DbConnectionString;

            var sqlConnection = new SQLiteConnection("data source=" + dbconnectionString);
            var dbContext = new ProUIDBContext(sqlConnection, true);
            return dbContext;
        }
    }
}
