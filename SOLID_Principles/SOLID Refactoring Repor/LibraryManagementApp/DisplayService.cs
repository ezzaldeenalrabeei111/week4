using System;
using System.Collections.Generic;
using LibraryManagementApp.Core;
using LibraryManagementApp.Model;

namespace LibraryManagementApp.Services
{
    public class DisplayService
    {
        public void DisplayItemDetails(LibraryItem item)
        {
            if (item != null)
            {
                item.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Display Error: Item is null.");
            }
        }

        public void DisplayItemList(List<LibraryItem> items, string header)
        {
            Console.WriteLine("\n--- {0} ---", header);
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("No items to display.");
                return;
            }

            foreach (var item in items)
            {
                item.DisplayInfo();
                Console.WriteLine("--------------------");
            }
        }

        public void DisplayMemberDetails(Member member)
        {
            if (member != null)
            {
                Console.WriteLine("--- Member Details ---");
                Console.WriteLine("ID: {0}", member.MemberId);
                Console.WriteLine("Name: {0}", member.Name);
                Console.WriteLine("Email: {0}", member.Email);
            }
            else
            {
                Console.WriteLine("Display Error: Member is null.");
            }
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine("\nMessage: {0}", message);
        }

        public void DisplayError(string errorMessage)
        {
            Console.WriteLine("\nError: {0}", errorMessage);
        }
    }
}
