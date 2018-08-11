
using BaseUI.ContentViewModel;
using ProUIApp.View.AccountView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProUIApp.View.ContentView
{
    /// <summary>
    /// Interaction logic for AccountContentPage.xaml
    /// </summary>
    public partial class AccountContentPage : UserControl
    {
        AccountContentPageViewModel objAccountViewModel = new AccountContentPageViewModel();
             
        public AccountContentPage()
        {
            InitializeComponent();
            InitializeValue();
           
        }

        private void InitializeValue()
        {
            try
            {
                DataContext = objAccountViewModel;
                objAccountViewModel.SelectedTab = new Lazy<UserControl>(AllAccountData.getObj);
            }
            catch(Exception ex) { }
        }

        private static AccountContentPage obj;
        public static AccountContentPage getObj()
        {
            return obj ?? (obj = new AccountContentPage());
        }
    }
}
