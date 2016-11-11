﻿namespace UwpBindingCache.Model
{
    public class Item : Observable
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
