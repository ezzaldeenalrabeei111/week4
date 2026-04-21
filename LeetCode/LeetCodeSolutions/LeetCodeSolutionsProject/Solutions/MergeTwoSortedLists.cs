using System;

namespace LeetCodeSolutions
{
    // تعريف ListNode كما هو موجود في LeetCode
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    /// <summary>
    /// حل مسألة LeetCode رقم 21: Merge Two Sorted Lists
    /// رابط المسألة: https://leetcode.com/problems/merge-two-sorted-lists/
    /// </summary>
    /// <remarks>
    /// **الوصف:**
    /// ادمج قائمتين مرتبطتين (linked lists) مصنفتين في قائمة مرتبطة واحدة.
    /// يجب أن يتم دمج القائمة الجديدة عن طريق ربط العقد (nodes) من القائمتين الأصليتين.
    /// أعد رأس القائمة المرتبطة المدمجة.
    /// 
    /// **مثال 1:**
    /// الإدخال: list1 = [1,2,4], list2 = [1,3,4]
    /// الإخراج: [1,1,2,3,4,4]
    /// 
    /// **مثال 2:**
    /// الإدخال: list1 = [], list2 = []
    /// الإخراج: []
    /// 
    /// **مثال 3:**
    /// الإدخال: list1 = [], list2 = [0]
    /// الإخراج: [0]
    /// </remarks>
    public class MergeTwoSortedListsSolution
    {
        /// <summary>
        /// يدمج قائمتين مرتبطتين مصنفتين في قائمة مرتبطة واحدة مصنفة.
        /// </summary>
        /// <param name="list1">رأس القائمة المرتبطة الأولى.</param>
        /// <param name="list2">رأس القائمة المرتبطة الثانية.</param>
        /// <returns>رأس القائمة المرتبطة المدمجة.</returns>
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            // حالة أساسية: إذا كانت إحدى القائمتين فارغة، نرجع الأخرى.
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            // نحدد رأس القائمة المدمجة.
            ListNode head;
            // نحدد المؤشر الذي سنتحرك به في القائمة المدمجة.
            ListNode current;

            // نختار العنصر الأصغر ليكون بداية القائمة المدمجة.
            if (list1.val <= list2.val)
            {
                head = list1;
                list1 = list1.next;
            }
            else
            {
                head = list2;
                list2 = list2.next;
            }
            current = head;

            // نكرر العملية طالما أن هناك عناصر في أي من القائمتين.
            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }
                current = current.next;
            }

            // إذا بقيت عناصر في إحدى القائمتين بعد انتهاء الأخرى، نربطها مباشرة.
            if (list1 != null)
            {
                current.next = list1;
            }
            else if (list2 != null)
            {
                current.next = list2;
            }

            return head;
        }
    }
}
