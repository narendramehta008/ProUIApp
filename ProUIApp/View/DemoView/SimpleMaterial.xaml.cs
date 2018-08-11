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

namespace ProUIApp.View.DemoView
{
    /// <summary>
    /// Interaction logic for SimpleMaterial.xaml
    /// </summary>
    public partial class SimpleMaterial : UserControl
    {
        public SimpleMaterial()
        {
            InitializeComponent();
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAirplane_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("By Plane");
        }

        private void ButtonTrain_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("By Train");
        }
    }
}
