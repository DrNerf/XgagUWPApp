using System;
using Windows.UI.Xaml;
using Controls = Windows.UI.Xaml.Controls;

namespace XgagUWPApp
{
    /// <summary>
    /// WebView attached properties.
    /// </summary>
    public class WebView
    {
        // "NavigateIfNotNull" attached property for a WebView
        public static readonly DependencyProperty NavigateIfNotNullProperty =
           DependencyProperty.RegisterAttached("NavigateIfNotNull", typeof(string), typeof(WebView), new PropertyMetadata("", OnNavigateIfNotNullChanged));

        // Getter and Setter
        public static string GetNavigateIfNotNull(DependencyObject obj) { return (string)obj.GetValue(NavigateIfNotNullProperty); }
        public static void SetNavigateIfNotNull(DependencyObject obj, string value) { obj.SetValue(NavigateIfNotNullProperty, value); }

        // Handler for property changes in the DataContext : set the WebView
        private static void OnNavigateIfNotNullChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Controls.WebView wv = d as Controls.WebView;
            if (wv != null)
            {
                if (e.NewValue != null)
                {
                    wv.Navigate(new Uri((string)e.NewValue));
                } 
            }
        }
    }
}
