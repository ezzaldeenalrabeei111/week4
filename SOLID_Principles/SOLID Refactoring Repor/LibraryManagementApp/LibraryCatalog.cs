using System;
using System.Collections.Generic;
using LibraryManagementApp.Core;

namespace LibraryManagementApp.Services
{
    public class LibraryCatalog
    {
        private List<LibraryItem> _items;

        public LibraryCatalog()
        {
            _items = new List<LibraryItem>();
        }

        public void AddItem(LibraryItem item)
        {
            if (item != null)
            {
                _items.Add(item);
                Console.WriteLine("Catalog: Item '{0}' added successfully.", item.Title);
            }
            else
            {
                Console.WriteLine("Catalog Error: Cannot add a null item.");
            }
        }

        public void RemoveItem(string isbn)
        {
            LibraryItem itemToRemove = _items.Find(item => item.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
                Console.WriteLine("Catalog: Item with ISBN '{0}' removed successfully.", isbn);
            }
            else
            {
                Console.WriteLine("Catalog Error: Item with ISBN '{0}' not found.", isbn);
            }
        }

        public List<LibraryItem> SearchItems(string query)
        {
            List<LibraryItem> results = new List<LibraryItem>();
            foreach (var item in _items)
            {
                if (item is ISearchable searchableItem)
                {
                    if (searchableItem.Search(query))
                    {
                        results.Add(item);
                    }
                }
            }
            Console.WriteLine("Catalog: Found {0} items matching '{1}'.", results.Count, query);
            return results;
        }

        public List<LibraryItem> GetAllItems()
        {
            return new List<LibraryItem>(_items);
        }
    }
}
