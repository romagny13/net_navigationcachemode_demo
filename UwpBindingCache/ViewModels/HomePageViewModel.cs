using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using UwpBindingCache.Model;

namespace UwpBindingCache.ViewModels
{
    public class HomePageViewModel : Observable
    {
        private string _createdTime;
        public string CreatedTime
        {
            get { return _createdTime; }
            set { SetProperty(ref _createdTime, value); }
        }

        private string _navigatedTime;
        public string NavigatedTime
        {
            get { return _navigatedTime; }
            set { SetProperty(ref _navigatedTime, value); }
        }

        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private IMyService _myService;

        // or dependency injection
        public HomePageViewModel(): this(new MyService()) { }
        public HomePageViewModel(IMyService myService)
        {
            _myService = myService;

            if (AppCache.Default.Has("items"))
            {
                Items = new ObservableCollection<Item>(AppCache.Default.Get<List<Item>>("items"));
                Debug.WriteLine("Items from cache");
            }
            else
            {
                var items = _myService.GetAll();
                Items = new ObservableCollection<Item>(items);
                AppCache.Default.Add("items", items);
            }
            CreatedTime = "Create view model  at " + DateTime.Now.ToString("HH:mm:ss");
        }

        public void LoadData()
        {
            NavigatedTime = "Navigated " + DateTime.Now.ToString("HH:mm:ss");
        }
    }


}
