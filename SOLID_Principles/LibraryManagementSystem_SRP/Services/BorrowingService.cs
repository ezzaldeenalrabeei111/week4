using System;
using LibraryManagementSystem.Core;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem.Services
{
    /// <summary>
    /// كلاس مسؤول عن إدارة عمليات استعارة وإرجاع عناصر المكتبة.
    /// يتبع مبدأ المسؤولية الواحدة (SRP).
    /// </summary>
    public class BorrowingService
    {
        private readonly LibraryCatalog _catalog;
        private readonly MemberService _memberService;

        /// <summary>
        /// منشئ الكلاس BorrowingService.
        /// يعتمد على LibraryCatalog و MemberService لإتمام العمليات.
        /// </summary>
        /// <param name="catalog">كتالوج المكتبة للبحث عن العناصر.</param>
        /// <param name="memberService">خدمة الأعضاء للبحث عن الأعضاء.</param>
        public BorrowingService(LibraryCatalog catalog, MemberService memberService)
        {
            if (catalog == null)
            {
                throw new ArgumentNullException("catalog", "LibraryCatalog cannot be null.");
            }
            if (memberService == null)
            {
                throw new ArgumentNullException("memberService", "MemberService cannot be null.");
            }

            _catalog = catalog;
            _memberService = memberService;
        }

        /// <summary>
        /// معالجة عملية استعارة عنصر من المكتبة.
        /// </summary>
        /// <param name="isbn">رقم ISBN للعنصر المراد استعارته.</param>
        /// <param name="memberId">الرقم التعريفي للعضو المستعير.</param>
        public void BorrowItem(string isbn, int memberId)
        {
            LibraryItem item = _catalog.FindItemByIsbn(isbn);
            Member member = _memberService.FindMemberById(memberId);

            if (item == null)
            {
                Console.WriteLine($"Error: Item with ISBN {isbn} not found.");
                return;
            }

            if (member == null)
            {
                Console.WriteLine($"Error: Member with ID {memberId} not found.");
                return;
            }

            // هنا نفترض أن Book هو النوع الوحيد القابل للاستعارة حالياً.
            // في المستقبل، يمكن استخدام واجهة IBorrowable لتطبيق OCP و LSP.
            Book book = item as Book;
            if (book != null)
            {
                if (!book.IsBorrowed)
                {
                    book.IsBorrowed = true;
                    Console.WriteLine($"Book: '{book.Title}' borrowed by {member.Name}.");
                }
                else
                {
                    Console.WriteLine($"Error: Book: '{book.Title}' is already borrowed.");
                }
            }
            else
            {
                Console.WriteLine($"Error: Item: '{item.Title}' cannot be borrowed.");
            }
        }

        /// <summary>
        /// معالجة عملية إرجاع عنصر إلى المكتبة.
        /// </summary>
        /// <param name="isbn">رقم ISBN للعنصر المراد إرجاعه.</param>
        public void ReturnItem(string isbn)
        {
            LibraryItem item = _catalog.FindItemByIsbn(isbn);

            if (item == null)
            {
                Console.WriteLine($"Error: Item with ISBN {isbn} not found.");
                return;
            }

            // هنا نفترض أن Book هو النوع الوحيد القابل للإرجاع حالياً.
            Book book = item as Book;
            if (book != null)
            {
                if (book.IsBorrowed)
                {
                    book.IsBorrowed = false;
                    Console.WriteLine($"Book: '{book.Title}' returned successfully.");
                }
                else
                {
                    Console.WriteLine($"Error: Book: '{book.Title}' was not borrowed.");
                }
            }
            else
            {
                Console.WriteLine($"Error: Item: '{item.Title}' cannot be returned.");
            }
        }
    }
}
