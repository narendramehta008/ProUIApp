using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseLibs.Models.DemoModels
{
    public class DemoModelTwo
    {
        [Key]
        [Index("Id", 1)]
        [Autoincrement]
        public long ID { get; set; }
        [Index("Name", 2)]
        public string Name { get; set; }
        [Index("ListData", 2)]
        public List<string> ListData { get; set; }

    }
}
