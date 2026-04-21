using System;

namespace LibraryManagementSystem.Core
{
    /// <summary>
    /// الكلاس الأساسي لجميع عناصر المكتبة (كتب، مجلات، إلخ).
    /// يحتوي على الخصائص المشتركة مثل العنوان، المؤلف، ورقم ISBN.
    /// </summary>
    public abstract class LibraryItem
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ISBN { get; private set; }

        /// <summary>
        /// منشئ الكلاس LibraryItem.
        /// </summary>
        /// <param name="title">عنوان العنصر.</param>
        /// <param name="author">مؤلف العنصر.</param>
        /// <param name="isbn">رقم ISBN الفريد للعنصر.</param>
        protected LibraryItem(string title, string author, string isbn)
        {
            // التحقق من صحة المدخلات الأساسية.
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Author cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentException("ISBN cannot be null or empty.");
            }

            Title = title;
            Author = author;
            ISBN = isbn;
        }

        /// <summary>
        /// دالة مجردة لعرض معلومات العنصر. يجب أن تنفذها الكلاسات المشتقة.
        /// </summary>
        public abstract void DisplayInfo();
    }

    /// <summary>
    /// كلاس يمثل كتابًا في المكتبة.
    /// </summary>
    public class Book : LibraryItem
    {
        public int PageCount { get; private set; }
        public bool IsBorrowed { get; set; } // حالة الاستعارة

        /// <summary>
        /// منشئ الكلاس Book.
        /// </summary>
        /// <param name="title">عنوان الكتاب.</param>
        /// <param name="author">مؤلف الكتاب.</param>
        /// <param name="isbn">رقم ISBN للكتاب.</param>
        /// <param name="pageCount">عدد صفحات الكتاب.</param>
        public Book(string title, string author, string isbn, int pageCount)
            : base(title, author, isbn)
        {
            if (pageCount <= 0)
            {
                throw new ArgumentException("Page count must be positive.");
            }
            PageCount = pageCount;
            IsBorrowed = false;
        }

        /// <summary>
        /// عرض معلومات الكتاب.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"Book: {Title} by {Author}, ISBN: {ISBN}, Pages: {PageCount}, Borrowed: {IsBorrowed}");
        }
    }
}
