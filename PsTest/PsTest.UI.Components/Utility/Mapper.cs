using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PsTest.UI.Components
{
    internal static class Mapper
    {
        public static Variant GetVariant(this UiVariant uIVariant)
        {
            Variant item;
            switch (uIVariant)
            {
                case UiVariant.Outlined:
                    item = Variant.Outlined;
                    break;
                case UiVariant.Text:
                    item = Variant.Text;
                    break;
                case UiVariant.Filled:
                    item = Variant.Filled;
                    break;
                default:
                    item = Variant.Outlined;
                    break;
            }
            return item;
        }

        public static Margin GetMargin(this UiMargin uiMargin)
        {
            Margin item;
            switch (uiMargin)
            {
                case UiMargin.None:
                    item = Margin.None;
                    break;
                case UiMargin.Normal:
                    item = Margin.Normal;
                    break;
                case UiMargin.Dense:
                    item = Margin.Dense;
                    break;
                default:
                    item = Margin.Dense;
                    break;
            }
            return item;
        }

        public static Color GetColor(this UiColor uiColor)
        {
            Color item;
            switch (uiColor)
            {
                case UiColor.Primary:
                    item = Color.Primary;
                    break;
                case UiColor.Secondary:
                    item = Color.Secondary;
                    break;
                case UiColor.Tertiary:
                    item = Color.Tertiary;
                    break;
                case UiColor.Info:
                    item = Color.Info;
                    break;
                case UiColor.Success:
                    item = Color.Success;
                    break;
                case UiColor.Warning:
                    item = Color.Warning;
                    break;
                case UiColor.Error:
                    item = Color.Error;
                    break;
                case UiColor.Dark:
                    item = Color.Dark;
                    break;
                case UiColor.Transparent:
                    item = Color.Transparent;
                    break;
                case UiColor.Inherit:
                    item = Color.Inherit;
                    break;
                case UiColor.Surface:
                    item = Color.Surface;
                    break;
                default:
                    item = Color.Default;
                    break;
            }
            return item;
        }
    }
}
