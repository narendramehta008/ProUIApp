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

namespace ProUIApp.View.AccountView
{
    /// <summary>
    /// Interaction logic for AllAccountData.xaml
    /// </summary>
    public partial class AllAccountData : UserControl
    {
        public AllAccountData()
        {
            InitializeComponent();
        }

        private static AllAccountData obj;
        public static AllAccountData getObj()
        {
            return obj ?? (obj = new AllAccountData());
        }
    }
}
