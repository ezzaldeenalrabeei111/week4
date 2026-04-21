using System;

namespace LeetCodeSolutions
{
    /// <summary>
    /// حل مسألة LeetCode رقم 704: Binary Search
    /// رابط المسألة: https://leetcode.com/problems/binary-search/
    /// </summary>
    /// <remarks>
    /// **الوصف:**
    /// بالنظر إلى مصفوفة من الأعداد الصحيحة `nums` مصنفة بترتيب تصاعدي،
    /// وعدد صحيح `target`، اكتب دالة للبحث عن `target` في `nums`.
    /// إذا كان `target` موجوداً، أعد فهرسه. وإلا، أعد -1.
    /// يجب أن تكتب خوارزمية بوقت تعقيد O(log n).
    /// 
    /// **مثال 1:**
    /// الإدخال: nums = [-1,0,3,5,9,12], target = 9
    /// الإخراج: 4
    /// الشرح: 9 موجود في nums وفهرسه 4.
    /// 
    /// **مثال 2:**
    /// الإدخال: nums = [-1,0,3,5,9,12], target = 2
    /// الإخراج: -1
    /// الشرح: 2 غير موجود في nums، لذلك نرجع -1.
    /// </remarks>
    public class BinarySearchSolution
    {
        /// <summary>
        /// يبحث عن العدد المستهدف في مصفوفة مصنفة باستخدام خوارزمية البحث الثنائي.
        /// </summary>
        /// <param name="nums">المصفوفة المصنفة من الأعداد الصحيحة.</param>
        /// <param name="target">العدد المستهدف للبحث عنه.</param>
        /// <returns>فهرس العدد المستهدف إذا وجد، وإلا -1.</returns>
        public int Search(int[] nums, int target)
        {
            // مؤشر البداية.
            int left = 0;
            // مؤشر النهاية.
            int right = nums.Length - 1;

            // نكرر العملية طالما أن مؤشر البداية أقل من أو يساوي مؤشر النهاية.
            while (left <= right)
            {
                // نحسب الفهرس الأوسط.
                // استخدام (right - left) / 2 + left لتجنب تجاوز سعة العدد الصحيح (integer overflow)
                // إذا كانت left و right كبيرتين جداً.
                int mid = left + (right - left) / 2;

                // إذا كان العنصر الأوسط هو الهدف، نرجع فهرسه.
                if (nums[mid] == target)
                {
                    return mid;
                }
                // إذا كان العنصر الأوسط أقل من الهدف، فهذا يعني أن الهدف
                // يجب أن يكون في النصف الأيمن من المصفوفة.
                else if (nums[mid] < target)
                {
                    left = mid + 1;
                }
                // إذا كان العنصر الأوسط أكبر من الهدف، فهذا يعني أن الهدف
                // يجب أن يكون في النصف الأيسر من المصفوفة.
                else
                {
                    right = mid - 1;
                }
            }

            // إذا لم يتم العثور على الهدف بعد انتهاء الحلقة، نرجع -1.
            return -1;
        }
    }
}
