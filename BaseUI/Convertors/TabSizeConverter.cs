using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace BaseUI.Convertors
{
    public class TabSizeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            #region grid
            Grid gridControl = values[0] as Grid;
            double height = gridControl.ActualHeight / gridControl.RowDefinitions.Count;
            //Subtract 1, otherwise we could overflow to two rows.
            return (height <= 1) ? 0 : (height - 1); 
            #endregion

            #region tab
            //TabControl tabControl = values[0] as TabControl;
            //double width = tabControl.ActualWidth / tabControl.Items.Count;
            ////Subtract 1, otherwise we could overflow to two rows.
            //return (width <= 1) ? 0 : (width - 1); 
            #endregion
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
