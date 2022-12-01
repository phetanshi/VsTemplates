using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWA.UI.Components
{
    public enum UiVariant
    {
        [Description("text")]
        Text,
        [Description("filled")]
        Filled,
        [Description("outlined")]
        Outlined
    }
}
