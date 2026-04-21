using System;
using LibraryManagementApp.Core;

namespace LibraryManagementApp.Core
{
    public abstract class LibraryItem : IDisplayable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        protected LibraryItem(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public abstract void DisplayInfo();
    }

    public class Book : LibraryItem, IBorrowable, ISearchable
    {
        public int PageCount { get; set; }
        public bool IsBorrowed { get; private set; }

        public Book(string title, string author, string isbn, int pageCount)
            : base(title, author, isbn)
        {
            PageCount = pageCount;
            IsBorrowed = false;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("--- Book Details ---");
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine("Author: {0}", Author);
            Console.WriteLine("ISBN: {0}", ISBN);
            Console.WriteLine("Pages: {0}", PageCount);
            Console.WriteLine("Status: {0}", IsBorrowed ? "Borrowed" : "Available");
        }

        public void BorrowItem()
        {
            if (!IsBorrowed)
            {
                IsBorrowed = true;
                Console.WriteLine("Success: Book '{0}' has been borrowed.", Title);
            }
            else
            {
                Console.WriteLine("Error: Book '{0}' is already borrowed.", Title);
            }
        }

        public void ReturnItem()
        {
            if (IsBorrowed)
            {
                IsBorrowed = false;
                Console.WriteLine("Success: Book '{0}' has been returned.", Title);
            }
            else
            {
                Console.WriteLine("Error: Book '{0}' was not borrowed.", Title);
            }
        }

        public bool Search(string query)
        {
            return Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   Author.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   ISBN.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }

    public class EBook : LibraryItem, ISearchable
    {
        public double FileSizeMB { get; set; }
        public string Format { get; set; }

        public EBook(string title, string author, string isbn, double fileSizeMB, string format)
            : base(title, author, isbn)
        {
            FileSizeMB = fileSizeMB;
            Format = format;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("--- EBook Details ---");
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine("Author: {0}", Author);
            Console.WriteLine("ISBN: {0}", ISBN);
            Console.WriteLine("File Size: {0} MB", FileSizeMB);
            Console.WriteLine("Format: {0}", Format);
            Console.WriteLine("Status: Always Available (Digital)");
        }

        public bool Search(string query)
        {
            return Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   Author.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   ISBN.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   Format.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }

    public class AudioBook : LibraryItem, IBorrowable, ISearchable
    {
        public int DurationMinutes { get; set; }
        public string Narrator { get; set; }
        public bool IsBorrowed { get; private set; }

        public AudioBook(string title, string author, string isbn, int durationMinutes, string narrator)
            : base(title, author, isbn)
        {
            DurationMinutes = durationMinutes;
            Narrator = narrator;
            IsBorrowed = false;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("--- AudioBook Details ---");
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine("Author: {0}", Author);
            Console.WriteLine("ISBN: {0}", ISBN);
            Console.WriteLine("Duration: {0} minutes", DurationMinutes);
            Console.WriteLine("Narrator: {0}", Narrator);
            Console.WriteLine("Status: {0}", IsBorrowed ? "Borrowed" : "Available");
        }

        public void BorrowItem()
        {
            if (!IsBorrowed)
            {
                IsBorrowed = true;
                Console.WriteLine("Success: AudioBook '{0}' has been borrowed.", Title);
            }
            else
            {
                Console.WriteLine("Error: AudioBook '{0}' is already borrowed.", Title);
            }
        }

        public void ReturnItem()
        {
            if (IsBorrowed)
            {
                IsBorrowed = false;
                Console.WriteLine("Success: AudioBook '{0}' has been returned.", Title);
            }
            else
            {
                Console.WriteLine("Error: AudioBook '{0}' was not borrowed.", Title);
            }
        }

        public bool Search(string query)
        {
            return Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   Author.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   ISBN.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   Narrator.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }

    public class Magazine : LibraryItem, IBorrowable, ISearchable
    {
        public int IssueNumber { get; set; }
        public DateTime PublicationDate { get; set; }
        public bool IsBorrowed { get; private set; }

        public Magazine(string title, string author, string isbn, int issueNumber, DateTime publicationDate)
            : base(title, author, isbn)
        {
            IssueNumber = issueNumber;
            PublicationDate = publicationDate;
            IsBorrowed = false;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("--- Magazine Details ---");
            Console.WriteLine("Title: {0}", Title);
            Console.WriteLine("Author: {0}", Author);
            Console.WriteLine("ISBN: {0}", ISBN);
            Console.WriteLine("Issue Number: {0}", IssueNumber);
            Console.WriteLine("Publication Date: {0:yyyy-MM-dd}", PublicationDate);
            Console.WriteLine("Status: {0}", IsBorrowed ? "Borrowed" : "Available");
        }

        public void BorrowItem()
        {
            if (!IsBorrowed)
            {
                IsBorrowed = true;
                Console.WriteLine("Success: Magazine '{0}' has been borrowed.", Title);
            }
            else
            {
                Console.WriteLine("Error: Magazine '{0}' is already borrowed.", Title);
            }
        }

        public void ReturnItem()
        {
            if (IsBorrowed)
            {
                IsBorrowed = false;
                Console.WriteLine("Success: Magazine '{0}' has been returned.", Title);
            }
            else
            {
                Console.WriteLine("Error: Magazine '{0}' was not borrowed.", Title);
            }
        }

        public bool Search(string query)
        {
            return Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   Author.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   ISBN.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   PublicationDate.ToString("yyyy-MM-dd").IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
