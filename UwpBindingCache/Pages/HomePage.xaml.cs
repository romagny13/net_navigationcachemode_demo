using System;
using System.Diagnostics;
using UwpBindingCache.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UwpBindingCache.Pages
{

    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;

            ViewModel = new HomePageViewModel();
            DataContext = ViewModel;

            CreatedTextBlock.Text = "Create page at " + DateTime.Now.ToString("HH:mm:ss");
        }

        public HomePageViewModel ViewModel { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.LoadData();
        }

    }
}
