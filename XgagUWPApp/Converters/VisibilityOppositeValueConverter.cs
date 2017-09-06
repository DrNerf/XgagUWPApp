using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace XgagUWPApp
{
    /// <summary>
    /// Visibility Value Converter.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Data.IValueConverter" />
    public class VisibilityOppositeValueConverter : IValueConverter
    {
        /// <summary>
        /// Converts the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="language">The language.</param>
        /// <returns>Visibility.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var booleanValue = value as bool?;
            if (booleanValue ?? false)
            {
                return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
