using System;
using UwpBindingCache.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UwpBindingCache.Pages
{

    public sealed partial class PageOne : Page
    {
        public PageOne()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Enabled;

            ViewModel = new PageOneViewModel();
            DataContext = ViewModel;

            CreatedTextBlock.Text = "created " + DateTime.Now.ToString("HH:mm:ss");
        }

        public PageOneViewModel ViewModel { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.LoadData();
        }
    }
}
