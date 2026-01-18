using System;
using System.Globalization;
using System.Windows.Data;

namespace BasicUIProject.Converter
{


    // internal：同じアセンブリ（同じプロジェクトのビルド成果物）内からだけ見え
    // public：他アセンブリからも見える
    // sealed は「継承させない」意図を示す

    public sealed class MinValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double doubleValue && parameter is string paramStr && double.TryParse(paramStr, out double min))
            {
                return Math.Max(doubleValue, min);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
