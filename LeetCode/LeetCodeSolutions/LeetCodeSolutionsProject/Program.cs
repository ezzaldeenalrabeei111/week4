using System;
using System.Collections.Generic;
using LeetCodeSolutions;

namespace LeetCodeSolutionsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- LeetCode Solutions Demo ---");
            Console.WriteLine("\n=================================================");

            // 1. Two Sum
            Console.WriteLine("1. Two Sum (Problem #1)");
            TwoSumSolution twoSumSolver = new TwoSumSolution();
            int[] nums1 = { 2, 7, 11, 15 };
            int target1 = 9;
            int[] result1 = twoSumSolver.TwoSum(nums1, target1);
            Console.WriteLine($"  Input: nums = [{string.Join(",", nums1)}], target = {target1}");
            Console.WriteLine($"  Output: [{result1[0]},{result1[1]}]");
            Console.WriteLine("-------------------------------------------------");

            // 2. Palindrome Number
            Console.WriteLine("2. Palindrome Number (Problem #9)");
            PalindromeNumberSolution palindromeSolver = new PalindromeNumberSolution();
            int x1 = 121;
            int x2 = -121;
            int x3 = 10;
            Console.WriteLine($"  Input: x = {x1}, Output: {palindromeSolver.IsPalindrome(x1)}");
            Console.WriteLine($"  Input: x = {x2}, Output: {palindromeSolver.IsPalindrome(x2)}");
            Console.WriteLine($"  Input: x = {x3}, Output: {palindromeSolver.IsPalindrome(x3)}");
            Console.WriteLine("-------------------------------------------------");

            // 3. Roman to Integer
            Console.WriteLine("3. Roman to Integer (Problem #13)");
            RomanToIntegerSolution romanToIntSolver = new RomanToIntegerSolution();
            string s1 = "III";
            string s2 = "LVIII";
            string s3 = "MCMXCIV";
            Console.WriteLine($"  Input: s = \"{s1}\", Output: {romanToIntSolver.RomanToInt(s1)}");
            Console.WriteLine($"  Input: s = \"{s2}\", Output: {romanToIntSolver.RomanToInt(s2)}");
            Console.WriteLine($"  Input: s = \"{s3}\", Output: {romanToIntSolver.RomanToInt(s3)}");
            Console.WriteLine("-------------------------------------------------");

            // 4. Valid Parentheses
            Console.WriteLine("4. Valid Parentheses (Problem #20)");
            ValidParenthesesSolution parenthesesSolver = new ValidParenthesesSolution();
            string p1 = "()";
            string p2 = "()[]{}";
            string p3 = "(]";
            Console.WriteLine($"  Input: s = \"{p1}\", Output: {parenthesesSolver.IsValid(p1)}");
            Console.WriteLine($"  Input: s = \"{p2}\", Output: {parenthesesSolver.IsValid(p2)}");
            Console.WriteLine($"  Input: s = \"{p3}\", Output: {parenthesesSolver.IsValid(p3)}");
            Console.WriteLine("-------------------------------------------------");

            // 5. Merge Two Sorted Lists
            Console.WriteLine("5. Merge Two Sorted Lists (Problem #21)");
            MergeTwoSortedListsSolution mergeListsSolver = new MergeTwoSortedListsSolution();
            ListNode l1_1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            ListNode l1_2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            ListNode mergedList1 = mergeListsSolver.MergeTwoLists(l1_1, l1_2);
            Console.Write("  Input: list1 = [1,2,4], list2 = [1,3,4], Output: [");
            PrintListNode(mergedList1);
            Console.WriteLine("]");
            Console.WriteLine("-------------------------------------------------");

            // 6. Remove Duplicates from Sorted Array
            Console.WriteLine("6. Remove Duplicates from Sorted Array (Problem #26)");
            RemoveDuplicatesFromSortedArraySolution removeDuplicatesSolver = new RemoveDuplicatesFromSortedArraySolution();
            int[] nums2 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int k = removeDuplicatesSolver.RemoveDuplicates(nums2);
            Console.WriteLine($"  Input: nums = [0,0,1,1,1,2,2,3,3,4], Output: k = {k}, nums = [{string.Join(",", nums2, 0, k)}]");
            Console.WriteLine("-------------------------------------------------");

            // 7. Best Time to Buy and Sell Stock
            Console.WriteLine("7. Best Time to Buy and Sell Stock (Problem #121)");
            BestTimeToBuyAndSellStockSolution stockSolver = new BestTimeToBuyAndSellStockSolution();
            int[] prices1 = { 7, 1, 5, 3, 6, 4 };
            int[] prices2 = { 7, 6, 4, 3, 1 };
            Console.WriteLine($"  Input: prices = [{string.Join(",", prices1)}], Output: {stockSolver.MaxProfit(prices1)}");
            Console.WriteLine($"  Input: prices = [{string.Join(",", prices2)}], Output: {stockSolver.MaxProfit(prices2)}");
            Console.WriteLine("-------------------------------------------------");

            // 8. Valid Anagram
            Console.WriteLine("8. Valid Anagram (Problem #242)");
            ValidAnagramSolution anagramSolver = new ValidAnagramSolution();
            string an1_s = "anagram";
            string an1_t = "nagaram";
            string an2_s = "rat";
            string an2_t = "car";
            Console.WriteLine($"  Input: s = \"{an1_s}\", t = \"{an1_t}\", Output: {anagramSolver.IsAnagram(an1_s, an1_t)}");
            Console.WriteLine($"  Input: s = \"{an2_s}\", t = \"{an2_t}\", Output: {anagramSolver.IsAnagram(an2_s, an2_t)}");
            Console.WriteLine("-------------------------------------------------");

            // 9. Binary Search
            Console.WriteLine("9. Binary Search (Problem #704)");
            BinarySearchSolution binarySearchSolver = new BinarySearchSolution();
            int[] bs_nums1 = { -1, 0, 3, 5, 9, 12 };
            int bs_target1 = 9;
            int bs_target2 = 2;
            Console.WriteLine($"  Input: nums = [{string.Join(",", bs_nums1)}], target = {bs_target1}, Output: {binarySearchSolver.Search(bs_nums1, bs_target1)}");
            Console.WriteLine($"  Input: nums = [{string.Join(",", bs_nums1)}], target = {bs_target2}, Output: {binarySearchSolver.Search(bs_nums1, bs_target2)}");
            Console.WriteLine("-------------------------------------------------");

            // 10. Reverse String
            Console.WriteLine("10. Reverse String (Problem #344)");
            ReverseStringSolution reverseStringSolver = new ReverseStringSolution();
            char[] rs_s1 = { 'h', 'e', 'l', 'l', 'o' };
            Console.Write($"  Input: s = [{string.Join(",", rs_s1)}], Output: [");
            reverseStringSolver.ReverseString(rs_s1);
            Console.Write(string.Join(",", rs_s1));
            Console.WriteLine("]");
            Console.WriteLine("-------------------------------------------------");

            Console.WriteLine("\n=================================================");
            Console.WriteLine("Demo Finished. Press any key to exit.");
            Console.ReadKey();
        }

        // دالة مساعدة لطباعة ListNode
        static void PrintListNode(ListNode node)
        {
            while (node != null)
            {
                Console.Write(node.val);
                if (node.next != null)
                {
                    Console.Write(",");
                }
                node = node.next;
            }
        }
    }
}
