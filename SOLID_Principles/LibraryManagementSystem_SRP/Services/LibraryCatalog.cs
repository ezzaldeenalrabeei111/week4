using System;
using System.Collections.Generic;
using System.Linq;
using LibraryManagementSystem.Core;

namespace LibraryManagementSystem.Services
{
    /// <summary>
    /// كلاس مسؤول عن إدارة كتالوج عناصر المكتبة (إضافة، حذف، بحث).
    /// يتبع مبدأ المسؤولية الواحدة (SRP).
    /// </summary>
    public class LibraryCatalog
    {
        private readonly List<LibraryItem> _items;

        /// <summary>
        /// منشئ الكلاس LibraryCatalog.
        /// </summary>
        public LibraryCatalog()
        {
            _items = new List<LibraryItem>();
        }

        /// <summary>
        /// إضافة عنصر جديد إلى كتالوج المكتبة.
        /// </summary>
        /// <param name="item">العنصر المراد إضافته.</param>
        public void AddItem(LibraryItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item", "Cannot add a null item to the catalog.");
            }
            // التحقق من عدم وجود عنصر بنفس رقم ISBN لتجنب التكرار.
            if (_items.Any(i => i.ISBN.Equals(item.ISBN, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"Error: Item with ISBN {item.ISBN} already exists.");
                return;
            }
            _items.Add(item);
            Console.WriteLine($"Item '{item.Title}' (ISBN: {item.ISBN}) added to catalog.");
        }

        /// <summary>
        /// إزالة عنصر من كتالوج المكتبة باستخدام رقم ISBN.
        /// </summary>
        /// <param name="isbn">رقم ISBN للعنصر المراد إزالته.</param>
        public void RemoveItem(string isbn)
        {
            LibraryItem itemToRemove = _items.FirstOrDefault(i => i.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));
            if (itemToRemove != null)
            {
                _items.Remove(itemToRemove);
                Console.WriteLine($"Item '{itemToRemove.Title}' (ISBN: {isbn}) removed from catalog.");
            }
            else
            {
                Console.WriteLine($"Error: Item with ISBN {isbn} not found.");
            }
        }

        /// <summary>
        /// البحث عن عنصر في الكتالوج باستخدام رقم ISBN.
        /// </summary>
        /// <param name="isbn">رقم ISBN للعنصر المراد البحث عنه.</param>
        /// <returns>العنصر إذا وجد، وإلا يعيد null.</returns>
        public LibraryItem FindItemByIsbn(string isbn)
        {
            return _items.FirstOrDefault(i => i.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// البحث عن عناصر بناءً على كلمة مفتاحية في العنوان أو المؤلف.
        /// </summary>
        /// <param name="query">الكلمة المفتاحية للبحث.</param>
        /// <returns>قائمة بالعناصر المطابقة.</returns>
        public List<LibraryItem> SearchItems(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return new List<LibraryItem>();
            }
            // استخدام IndexOf بدلاً من Contains للتوافق مع .NET Framework 4.8 بشكل أفضل إذا كان هناك قلق بشأن الأداء في بعض السيناريوهات.
            // ومع ذلك، Linq's Contains يعمل بشكل جيد لمعظم الحالات.
            string lowerQuery = query.ToLower();
            return _items.Where(item => 
                item.Title.ToLower().IndexOf(lowerQuery, StringComparison.OrdinalIgnoreCase) >= 0 || 
                item.Author.ToLower().IndexOf(lowerQuery, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();
        }

        /// <summary>
        /// الحصول على جميع العناصر الموجودة في الكتالوج.
        /// </summary>
        /// <returns>قائمة بجميع عناصر المكتبة.</returns>
        public List<LibraryItem> GetAllItems()
        {
            return new List<LibraryItem>(_items);
        }
    }
}
