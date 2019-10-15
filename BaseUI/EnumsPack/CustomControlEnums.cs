using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseUI.EnumsPack
{
    class CustomControlEnums
    {
    }

    public enum PattenTypes
    {
        [Description("LangKeyRegex")]
        Regex = 1,
        [Description("LangKeyGetBetween")]
        GetBetween = 2,
        [Description("LangKeyHtmlAgility")]
        HtmlAgility = 3,
    }
}
