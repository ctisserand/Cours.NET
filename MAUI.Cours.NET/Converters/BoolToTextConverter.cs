using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MAUI.Cours.NET.Converters
{
    public sealed class BoolToTextConverter : IValueConverter
    {
        public string TrueText { get; set; } = "Disable";
        public string FalseText { get; set; } = "Enable";

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool flag)
            {
                return flag ? TrueText : FalseText;
            }

            return FalseText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("BoolToTextConverter does not support ConvertBack.");
        }
    }
}
