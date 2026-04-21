using System;
using System.Collections.Generic;
using LibraryManagementApp.Core;
using LibraryManagementApp.Model;
using LibraryManagementApp.Services;

namespace LibraryManagementApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // تهيئة الخدمات مع تطبيق DIP (Dependency Injection)
            LibraryCatalog catalog = new LibraryCatalog();
            MemberService memberService = new MemberService();
            // نختار هنا EmailNotifier، ولكن يمكن استبداله بأي INotificationService آخر
            INotificationService emailNotifier = new EmailNotifier();
            BorrowingService borrowingService = new BorrowingService(catalog, memberService, emailNotifier);
            DisplayService displayService = new DisplayService();
            InputHelper inputHelper = new InputHelper();

            // إضافة بعض العناصر والأعضاء لتجربة النظام
            Book book1 = new Book("The Lord of the Rings", "J.R.R. Tolkien", "978-0618053267", 1178);
            EBook ebook1 = new EBook("Clean Code", "Robert Martin", "978-0132350884", 5.5, "PDF");
            AudioBook audiobook1 = new AudioBook("The Pragmatic Programmer", "Andrew Hunt", "978-0135957059", 600, "Full Cast");
            Magazine magazine1 = new Magazine("National Geographic", "Various", "978-1234567890", 150, new DateTime(2023, 10, 1));

            catalog.AddItem(book1);
            catalog.AddItem(ebook1);
            catalog.AddItem(audiobook1);
            catalog.AddItem(magazine1);

            Member member1 = new Member(1, "Alice Smith", "alice@example.com");
            Member member2 = new Member(2, "Bob Johnson", "bob@example.com");

            memberService.AddMember(member1);
            memberService.AddMember(member2);

            displayService.DisplayMessage("Welcome to the SOLID Refactored Library Management System!");

            bool running = true;
            while (running)
            {
                displayService.DisplayMessage("\n--- Main Menu ---");
                displayService.DisplayMessage("1. Display All Items");
                displayService.DisplayMessage("2. Search Items");
                displayService.DisplayMessage("3. Borrow Item");
                displayService.DisplayMessage("4. Return Item");
                displayService.DisplayMessage("5. Exit");

                string choice = inputHelper.GetStringInput("Enter your choice");

                switch (choice)
                {
                    case "1":
                        displayService.DisplayItemList(catalog.GetAllItems(), "All Library Items");
                        break;
                    case "2":
                        string searchQuery = inputHelper.GetStringInput("Enter search query");
                        List<LibraryItem> searchResults = catalog.SearchItems(searchQuery);
                        displayService.DisplayItemList(searchResults, "Search Results");
                        break;
                    case "3":
                        string borrowIsbn = inputHelper.GetStringInput("Enter ISBN of item to borrow");
                        int borrowMemberId = inputHelper.GetIntInput("Enter your Member ID");
                        borrowingService.BorrowItem(borrowIsbn, borrowMemberId);
                        break;
                    case "4":
                        string returnIsbn = inputHelper.GetStringInput("Enter ISBN of item to return");
                        int returnMemberId = inputHelper.GetIntInput("Enter your Member ID");
                        borrowingService.ReturnItem(returnIsbn, returnMemberId);
                        break;
                    case "5":
                        running = false;
                        displayService.DisplayMessage("Exiting Library System. Goodbye!");
                        break;
                    default:
                        displayService.DisplayError("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
