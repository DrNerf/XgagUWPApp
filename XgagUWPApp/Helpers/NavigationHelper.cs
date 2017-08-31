using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace XgagUWPApp
{
    public static class NavigationHelper
    {
        public static void Navigate(Type sourcePageType)
        {
            ((Frame)Window.Current.Content).Navigate(sourcePageType);
        }

        public static void Navigate(Type sourcePageType, object parameter)
        {
            ((Frame)Window.Current.Content).Navigate(sourcePageType, parameter);
        }

        public static void GoBack()
        {
            ((Frame)Window.Current.Content).GoBack();
        }
    }
}
