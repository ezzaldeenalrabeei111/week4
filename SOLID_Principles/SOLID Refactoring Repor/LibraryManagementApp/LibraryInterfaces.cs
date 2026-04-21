using System;

namespace LibraryManagementApp.Core
{
    public interface IDisplayable
    {
        void DisplayInfo();
    }

    public interface IBorrowable
    {
        bool IsBorrowed { get; }
        void BorrowItem();
        void ReturnItem();
    }

    public interface ISearchable
    {
        bool Search(string query);
    }
}
