using System;
using UwpBindingCache.Model;
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

            CreatedTextBlock.Text = "Create page at " + DateTime.Now.ToString("HH:mm:ss");
        }

        public PageTwoViewModel ViewModel { get; set; }

        private void SavePageStates()
        {
            AppData.SaveSetting("TextBox.Text", TextBox.Text);
            AppData.SaveSetting("ListView.SelectedIndex", ListView.SelectedIndex);
        }

        private void RestorePageStates()
        {
            // restore
            var text = AppData.GetSetting("TextBox.Text");
            if (text != null)
            {
                TextBox.Text = text.ToString();
            }

            var index = AppData.GetSetting("ListView.SelectedIndex");
            if (index != null)
            {
                ListView.SelectedIndex = (int)index;
            }
        }

        private void RemovePageStates()
        {
            AppData.RemoveSetting("TextBox.Text");
            AppData.RemoveSetting("ListView.SelectedIndex");
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            SavePageStates();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.LoadData();

            if (e.NavigationMode == NavigationMode.Back 
                || e.NavigationMode == NavigationMode.Forward)
            {
                RestorePageStates();
            }
            RemovePageStates();
        }
    }
}
