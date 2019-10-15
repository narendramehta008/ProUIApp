using SQLite.CodeFirst;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseLibs.Models.SocialModels
{
  public class WebHeaderModel 
    {
        [Key]
        [Autoincrement]
        [Index]
        [Column(Order = 1)]
        public long Id { get; set; }

        [Column(Order = 2)]
        public string MainUrl { get; set; }

        [Column(Order = 3)]
        public string PageUrl { get; set; }

        [Column(Order = 4)]
        public string PageUrlFormat { get; set; }

        [Column(Order = 5)]
        public string PostData { get; set; }
        [Column(Order = 6)]
        public string PostDataFormat { get; set; }

        [Column(Order = 7)]
        public string HeaderType { get; set; }
       

        [Column(Order = 8)]
        public string HeaderTypeWithValues { get; set; }
       
        [Column(Order = 9)]
        public string Referer { get; set; }

        [Column(Order = 10)]
        public string TokenFormat { get; set; }
        [Column(Order = 11)]
        public string RefererFormat { get; set; }

        [Column(Order = 12)]
        public string Token { get; set; }

        [Column(Order = 13)]
        public string ExtraField1 { get; set; }

        [Column(Order = 14)]
        public string ExtraFieldFormat1 { get; set; }

        [Column(Order = 15)]
        public string ExtraField2 { get; set; }

        [Column(Order = 16)]
        public string ExtraFieldFormat2 { get; set; }
        [Column(Order = 17)]
        public string ExtraField3 { get; set; }

        [Column(Order = 18)]
        public string ExtraFieldFormat3 { get; set; }

    }
}
