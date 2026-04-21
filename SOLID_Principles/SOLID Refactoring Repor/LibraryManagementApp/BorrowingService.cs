using System;
using System.Collections.Generic;
using LibraryManagementApp.Core;
using LibraryManagementApp.Model;

namespace LibraryManagementApp.Services
{
    public class BorrowingService
    {
        private LibraryCatalog _catalog;
        private MemberService _memberService;
        private INotificationService _notificationService;

        public BorrowingService(LibraryCatalog catalog, MemberService memberService, INotificationService notificationService)
        {
            _catalog = catalog;
            _memberService = memberService;
            _notificationService = notificationService;
        }

        public void BorrowItem(string isbn, int memberId)
        {
            LibraryItem item = _catalog.GetAllItems().Find(i => i.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));
            Member member = _memberService.FindMemberById(memberId);

            if (item == null)
            {
                Console.WriteLine("Borrowing Error: Item with ISBN '{0}' not found.", isbn);
                return;
            }

            if (member == null)
            {
                Console.WriteLine("Borrowing Error: Member with ID '{0}' not found.", memberId);
                return;
            }

            if (item is IBorrowable borrowableItem)
            {
                if (!borrowableItem.IsBorrowed)
                {
                    borrowableItem.BorrowItem();
                    Console.WriteLine("Borrowing: Member '{0}' borrowed '{1}' successfully.", member.Name, item.Title);
                    _notificationService.SendNotification(member.Email, "You have successfully borrowed '" + item.Title + "'.");
                }
                else
                {
                    Console.WriteLine("Borrowing Error: Item '{0}' is already borrowed.", item.Title);
                }
            }
            else
            {
                Console.WriteLine("Borrowing Error: Item '{0}' is not borrowable.", item.Title);
            }
        }

        public void ReturnItem(string isbn, int memberId)
        {
            LibraryItem item = _catalog.GetAllItems().Find(i => i.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));
            Member member = _memberService.FindMemberById(memberId);

            if (item == null)
            {
                Console.WriteLine("Returning Error: Item with ISBN '{0}' not found.", isbn);
                return;
            }

            if (member == null)
            {
                Console.WriteLine("Returning Error: Member with ID '{0}' not found.", memberId);
                return;
            }

            if (item is IBorrowable borrowableItem)
            {
                if (borrowableItem.IsBorrowed)
                {
                    borrowableItem.ReturnItem();
                    Console.WriteLine("Returning: Member '{0}' returned '{1}' successfully.", member.Name, item.Title);
                    _notificationService.SendNotification(member.Email, "You have successfully returned '" + item.Title + "'.");
                }
                else
                {
                    Console.WriteLine("Returning Error: Item '{0}' was not borrowed.", item.Title);
                }
            }
            else
            {
                Console.WriteLine("Returning Error: Item '{0}' is not borrowable.", item.Title);
            }
        }
    }
}
