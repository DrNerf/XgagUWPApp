using Microsoft.Toolkit.Uwp.UI.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace XgagUWPApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            DataContext = new HomePageViewModel();
        }

        private void OnMenuItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = e.ClickedItem as MenuItem;
            if (menuItem.PageType != null)
            {
                ContentFrame.Navigate(menuItem.PageType);
            }
        }

        private void HamburgerMenu_Loaded(object sender, RoutedEventArgs e)
        {
            var hamburgerMenu = sender as HamburgerMenu;
            if (hamburgerMenu != null)
            {
                hamburgerMenu.SelectedIndex = 0;
                var menuItem = hamburgerMenu.SelectedItem as MenuItem;
                if (menuItem != null && menuItem.PageType != null)
                {
                    ContentFrame.Navigate(menuItem.PageType); 
                }
            }
        }
    }
}
