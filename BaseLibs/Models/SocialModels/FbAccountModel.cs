using BaseLibs.Handlers.BindManager;
using SQLite.CodeFirst;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseLibs.Models.SocialModels
{
  
    public class FbAccountModel : BindableObject
    {
        private long _Id;
        private string _LoginUsername;// { get; set; }
        private string _Email;//{ get; set; }


        [Key]
        [Autoincrement]
        [Index]
        [Column(Order = 1)]
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        // used by user for login because it may use username or email 
        [Column(Order = 2)]
        public string LoginUsername
        {
            get { return _LoginUsername; }
            set { SetProperty(ref _LoginUsername, value); }
        }

        [Column(Order = 3)]
        public string Username { get; set; }

        [Column(Order = 4)]
        public string Email { get; set; }

        [Column(Order = 5)]
        public string password { get; set; }
        [Column(Order = 6)]
        public string Status { get; set; }

        [Column(Order = 7)]
        public string FullName { get; set; }


        [Column(Order = 8)]
        public string FriendsCount { get; set; }

        [Column(Order = 9)]
        public string GroupsCount { get; set; }

        [Column(Order = 10)]
        public string PagesCount { get; set; }

        [Column(Order = 11)]
        public string ProfilePicUrl { get; set; }

        [Column(Order = 12)]
        public string BannerPicUrl { get; set; }

        [Column(Order = 13)]
        public string PhoneNumber { get; set; }

        [Column(Order = 14)]
        public string Bio { get; set; }

        [Column(Order = 15)]
        public string OtherDetails { get; set; }

        [Column(Order = 16)]
        public string Session { get; set; }
        [Column(Order = 17)]
        public string CachePath { get; set; }

    }
}
