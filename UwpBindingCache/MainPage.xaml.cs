using UwpBindingCache.Pages;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UwpBindingCache
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainFrame.Navigating += MainFrame_Navigating;
            MainFrame.Navigate(typeof(HomePage));
        }

        private void MainFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            // clear cache on navigation new and home page 
           if(e.SourcePageType == typeof(HomePage) && e.NavigationMode == NavigationMode.New)
            {
                var cacheSize = MainFrame.CacheSize;
                MainFrame.CacheSize = 0;
                MainFrame.CacheSize = cacheSize;
            }
        }

        private void OnGoHomePage(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(HomePage));
        }

        private void OnGoPageTwo(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(PageTwo));
        }

        private void OnGoBack(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }

        private void OnGoForward(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoForward)
            {
                MainFrame.GoForward();
            }
        }


    }
}
