using System;
using System.Collections.Generic;
using LibraryManagementSystem.Core;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // تهيئة الخدمات المختلفة باستخدام حقن التبعية (Dependency Injection)
            // هذا يضمن أن كل خدمة مسؤولة عن وظيفة واحدة (SRP)
            LibraryCatalog catalog = new LibraryCatalog();
            MemberService memberService = new MemberService();
            BorrowingService borrowingService = new BorrowingService(catalog, memberService);
            DisplayService displayService = new DisplayService();

            // إضافة بعض البيانات الأولية لاختبار النظام
            catalog.AddItem(new Book("The Great Gatsby", "F. Scott Fitzgerald", "978-0743273565", 180));
            catalog.AddItem(new Book("1984", "George Orwell", "978-0451524935", 328));
            catalog.AddItem(new Magazine("National Geographic", "National Geographic Society", "978-1234567890", 250));
            catalog.AddItem(new DVD("The Matrix", "The Wachowskis", "978-0790747010", 136));
            memberService.AddMember(new Member(101, "Alice Smith", "alice@example.com"));
            memberService.AddMember(new Member(102, "Bob Johnson", "bob@example.com"));

            bool running = true;
            while (running)
            {
                displayService.DisplayMainMenu();
                string choice = displayService.GetStringInput("Your choice: ");

                switch (choice)
                {
                    case "1": // Add New Book
                        string bookTitle = displayService.GetStringInput("Enter book title: ");
                        string bookAuthor = displayService.GetStringInput("Enter book author: ");
                        string bookIsbn = displayService.GetStringInput("Enter book ISBN: ");
                        int pageCount = displayService.GetIntInput("Enter page count: ");
                        catalog.AddItem(new Book(bookTitle, bookAuthor, bookIsbn, pageCount));
                        break;

                    case "2": // Add New Magazine
                        string magTitle = displayService.GetStringInput("Enter magazine title: ");
                        string magPublisher = displayService.GetStringInput("Enter magazine publisher: ");
                        string magIsbn = displayService.GetStringInput("Enter magazine ISBN: ");
                        int issueNum = displayService.GetIntInput("Enter issue number: ");
                        catalog.AddItem(new Magazine(magTitle, magPublisher, magIsbn, issueNum));
                        break;

                    case "3": // Add New DVD
                        string dvdTitle = displayService.GetStringInput("Enter DVD title: ");
                        string dvdDirector = displayService.GetStringInput("Enter DVD director: ");
                        string dvdIsbn = displayService.GetStringInput("Enter DVD ISBN: ");
                        int duration = displayService.GetIntInput("Enter duration in minutes: ");
                        catalog.AddItem(new DVD(dvdTitle, dvdDirector, dvdIsbn, duration));
                        break;

                    case "4": // Find Item by ISBN
                        string findIsbn = displayService.GetStringInput("Enter ISBN to find: ");
                        LibraryItem foundItem = catalog.FindItemByIsbn(findIsbn);
                        displayService.DisplayItemDetails(foundItem);
                        break;

                    case "5": // Search Items by Title/Author
                        string searchQuery = displayService.GetStringInput("Enter search query (title/author): ");
                        List<LibraryItem> searchResults = catalog.SearchItems(searchQuery);
                        displayService.DisplayItemsList(searchResults);
                        break;

                    case "6": // Add New Member
                        int memberId = displayService.GetIntInput("Enter member ID: ");
                        string memberName = displayService.GetStringInput("Enter member name: ");
                        string contactInfo = displayService.GetStringInput("Enter contact info (email/phone): ");
                        memberService.AddMember(new Member(memberId, memberName, contactInfo));
                        break;

                    case "7": // Find Member by ID
                        int findMemberId = displayService.GetIntInput("Enter member ID to find: ");
                        Member foundMember = memberService.FindMemberById(findMemberId);
                        displayService.DisplayMemberDetails(foundMember);
                        break;

                    case "8": // Borrow Item
                        string borrowIsbn = displayService.GetStringInput("Enter ISBN of book to borrow: ");
                        int borrowerId = displayService.GetIntInput("Enter member ID: ");
                        borrowingService.BorrowItem(borrowIsbn, borrowerId);
                        break;

                    case "9": // Return Item
                        string returnIsbn = displayService.GetStringInput("Enter ISBN of book to return: ");
                        borrowingService.ReturnItem(returnIsbn);
                        break;

                    case "10": // List All Items
                        displayService.DisplayItemsList(catalog.GetAllItems());
                        break;

                    case "11": // List All Members
                        displayService.DisplayMembersList(memberService.GetAllMembers());
                        break;

                    case "0": // Exit
                        running = false;
                        displayService.DisplayMessage("Exiting Library Management System. Goodbye!");
                        break;

                    default:
                        displayService.DisplayMessage("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine(); // سطر فارغ للفصل بين العمليات
            }
        }
    }
}
