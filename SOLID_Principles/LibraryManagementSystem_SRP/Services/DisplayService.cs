using System;
using System.Collections.Generic;
using LibraryManagementSystem.Core;

namespace LibraryManagementSystem.Services
{
    /// <summary>
    /// كلاس مسؤول عن عرض جميع المخرجات للمستخدم على الكونسول.
    /// يتبع مبدأ المسؤولية الواحدة (SRP).
    /// </summary>
    public class DisplayService
    {
        /// <summary>
        /// عرض رسالة عامة للمستخدم.
        /// </summary>
        /// <param name="message">الرسالة المراد عرضها.</param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// عرض تفاصيل عنصر مكتبة واحد.
        /// </summary>
        /// <param name="item">عنصر المكتبة المراد عرضه.</param>
        public void DisplayItemDetails(LibraryItem item)
        {
            if (item == null)
            {
                Console.WriteLine("Item details not available.");
                return;
            }
            item.DisplayInfo(); // تستخدم دالة DisplayInfo الخاصة بكل نوع من LibraryItem
        }

        /// <summary>
        /// عرض قائمة بعناصر المكتبة.
        /// </summary>
        /// <param name="items">قائمة عناصر المكتبة المراد عرضها.</param>
        public void DisplayItemsList(List<LibraryItem> items)
        {
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("No items to display.");
                return;
            }
            Console.WriteLine("--- Library Items ---");
            foreach (var item in items)
            {
                item.DisplayInfo();
            }
            Console.WriteLine("---------------------");
        }

        /// <summary>
        /// عرض تفاصيل عضو واحد.
        /// </summary>
        /// <param name="member">العضو المراد عرضه.</param>
        public void DisplayMemberDetails(Member member)
        {
            if (member == null)
            {
                Console.WriteLine("Member details not available.");
                return;
            }
            member.DisplayInfo();
        }

        /// <summary>
        /// عرض قائمة بالأعضاء.
        /// </summary>
        /// <param name="members">قائمة الأعضاء المراد عرضها.</param>
        public void DisplayMembersList(List<Member> members)
        {
            if (members == null || members.Count == 0)
            {
                Console.WriteLine("No members to display.");
                return;
            }
            Console.WriteLine("--- Library Members ---");
            foreach (var member in members)
            {
                member.DisplayInfo();
            }
            Console.WriteLine("---------------------");
        }

        /// <summary>
        /// عرض قائمة الخيارات الرئيسية للمستخدم.
        /// </summary>
        public void DisplayMainMenu()
        {
            Console.WriteLine("\n--- Library Management System ---");
            Console.WriteLine("1. Add New Book");
            Console.WriteLine("2. Find Book by ISBN");
            Console.WriteLine("3. Search Books by Title/Author");
            Console.WriteLine("4. Add New Member");
            Console.WriteLine("5. Find Member by ID");
            Console.WriteLine("6. Borrow Book");
            Console.WriteLine("7. Return Book");
            Console.WriteLine("8. List All Books");
            Console.WriteLine("9. List All Members");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
        }

        /// <summary>
        /// قراءة مدخل نصي من المستخدم.
        /// </summary>
        /// <param name="prompt">الرسالة التي تظهر للمستخدم قبل الإدخال.</param>
        /// <returns>النص الذي أدخله المستخدم.</param>
        public string GetStringInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        /// <summary>
        /// قراءة مدخل رقمي صحيح من المستخدم.
        /// </summary>
        /// <param name="prompt">الرسالة التي تظهر للمستخدم قبل الإدخال.</param>
        /// <returns>الرقم الصحيح الذي أدخله المستخدم.</param>
        public int GetIntInput(string prompt)
        {
            int result;
            string input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (int.TryParse(input, out result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}
