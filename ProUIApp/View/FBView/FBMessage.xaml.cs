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
    /// Interaction logic for FBMessage.xaml
    /// </summary>
    public partial class FBMessage : UserControl
    {
        public FBMessage()
        {
            InitializeComponent();
        }

        private static FBMessage obj;

        public static FBMessage getObj()
        {
            if (obj == null)
                return obj = new FBMessage();
            return obj;
        }
    }
}
