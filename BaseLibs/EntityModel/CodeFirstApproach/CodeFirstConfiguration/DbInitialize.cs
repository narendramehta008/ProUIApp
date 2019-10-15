using BaseLibs.Models;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.EntityModel.CodeFirstApproach.CodeFirstConfiguration
{
        public class DbInitialize : SqliteCreateDatabaseIfNotExists<ProUIDBContext>//SqliteDropCreateDatabaseWhenModelChanges<ProUIDBContext>
        {
            public DbInitialize(DbModelBuilder dbModelBuilder): base(dbModelBuilder)
            {

            }
        }

    
}
