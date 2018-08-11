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

namespace ProUIApp.View.FBView
{
    /// <summary>
    /// Interaction logic for FBMedia.xaml
    /// </summary>
    public partial class FBMedia : UserControl
    {
        public FBMedia()
        {
            InitializeComponent();
        }

        private static FBMedia obj;

        public static FBMedia getObj()
        {
            if (obj == null)
                return obj = new FBMedia();
            return obj;
        }
    }
}
