using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BaseLibs.Models.DemoModels
{
   public class DemoModelOne
    {
        [Key]
        [Autoincrement]
        [Index]
        [Column(Order =1)]
        public long ID { get; set; }
        [Column(Order = 2)]
        public string Name { get; set; }
        //[Column(Order = 3)]
        //public List<string> ListData { get; set; }

    }
}
