using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using UwpBindingCache.Model;

namespace UwpBindingCache.ViewModels
{
    public class PageOneViewModel : Observable
    {
        private string _time;
        public string Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }

        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public PageOneViewModel()
        {
            var items = new List<Item>
                {
                    new Item { Name = "Item 1" },
                    new Item { Name = "Item 2" },
                    new Item { Name = "Item 3" }
                };
            Items = new ObservableCollection<Item>(items);
            Debug.WriteLine("Create page 1 view model  at " + DateTime.Now.ToString("HH:mm:ss"));
        }

        public void LoadData()
        {
            Time = "Navigated " + DateTime.Now.ToString("HH:mm:ss");
        }
    }


}
