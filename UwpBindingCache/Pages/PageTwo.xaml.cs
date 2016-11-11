using System;
using UwpBindingCache.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace UwpBindingCache.Pages
{
    public sealed partial class PageTwo : Page
    {
        public PageTwo()
        {
            this.InitializeComponent();

            ViewModel = new PageTwoViewModel();
            DataContext = ViewModel;

            CreatedTextBlock.Text = "created " + DateTime.Now.ToString("HH:mm:ss");
        }

        public PageTwoViewModel ViewModel { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.LoadData();
        }
    }
}
