using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;

namespace BaseUI.MainViewModel
{
   public class TabItemTemplate
    {
        public string TabName { get; set; }
        public Lazy<UserControl>  TabTemplate { get; set; }
        public PackIconKind IconType;
    }
}
