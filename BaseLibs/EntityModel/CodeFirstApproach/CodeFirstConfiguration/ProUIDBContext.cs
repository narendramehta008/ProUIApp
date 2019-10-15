using BaseLibs.Models.SocialModels;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.EntityModel.CodeFirstApproach.CodeFirstConfiguration
{
   public class ProUIDBContext : DbContext
    {
        public ProUIDBContext(string DbConnectionstring):
            base(DbConnectionstring)
        {
            configure();
        }

        public ProUIDBContext(DbConnection dbConnection, bool IsContextOwnsConnection) :
           base(dbConnection, IsContextOwnsConnection)
        {
            configure();
        }

        private void configure()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            try
            {
                modelBuilder.Entity<TwtAccountModel>();
                modelBuilder.Entity<FbAccountModel>();
                modelBuilder.Entity<WebHeaderModel>();
                modelBuilder.Entity<WebAccounts>();
                var Initializer = new DbInitialize(modelBuilder);
                Database.SetInitializer(Initializer);
            }catch(Exception ex)
            {
            }
        }
    }
}
