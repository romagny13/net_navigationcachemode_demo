using System.Collections.Generic;

namespace UwpBindingCache.Model
{
    public class MyService : IMyService
    {
        private static List<Item> items;

        static MyService()
        {
            items = new List<Item>
                {
                    new Item { Name = "Item 1" },
                    new Item { Name = "Item 2" },
                    new Item { Name = "Item 3" }
                };
        }

        public List<Item> GetAll ()
        {
            return items;
        }

    }
}
