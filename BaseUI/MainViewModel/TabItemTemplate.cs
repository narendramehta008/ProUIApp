using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BaseUI.MainViewModel
{
   public class TabItemTemplate
    {
        public string TabName { get; set; }
        public Lazy<UserControl>  TabTemplate { get; set; }
    }
}
