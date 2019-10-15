using BaseLibs.Models.DemoModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibs.EntityModel.CodeFirstApproach.CodeFirstConfiguration
{
    public class ModelConfiguration
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
           // ConfigureTeamEntity(modelBuilder);
            //ConfigureStadionEntity(modelBuilder);
            //ConfigureCoachEntity(modelBuilder);
            //ConfigurePlayerEntity(modelBuilder);
            //ConfigureSelfReferencingEntities(modelBuilder);
        }

        //private static void ConfigureTeamEntity(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<DemoModelOne>().ToTable("Base.MyTable")
        //        .HasRequired(t => t.ListData)
        //        .WithMany()
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<DemoModelTwo>()
        //        .HasRequired(t => t.Name)
        //        .WithRequiredPrincipal()
        //        .WillCascadeOnDelete(true);
        //}

        //private static void ConfigureStadionEntity(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Stadion>();
        //}

        //private static void ConfigureCoachEntity(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Coach>()
        //        .HasRequired(p => p.Team)
        //        .WithRequiredPrincipal(t => t.Coach)
        //        .WillCascadeOnDelete(false);
        //}

        //private static void ConfigurePlayerEntity(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Player>()
        //        .HasRequired(p => p.Team)
        //        .WithMany(team => team.Players)
        //        .WillCascadeOnDelete(true);
        //}

        //private static void ConfigureSelfReferencingEntities(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Foo>();
        //    modelBuilder.Entity<FooSelf>();
        //    modelBuilder.Entity<FooStep>();
        //}
    }
}
