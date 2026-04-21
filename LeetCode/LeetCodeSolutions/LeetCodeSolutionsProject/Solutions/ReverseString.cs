using System;

namespace LeetCodeSolutions
{
    /// <summary>
    /// حل مسألة LeetCode رقم 344: Reverse String
    /// رابط المسألة: https://leetcode.com/problems/reverse-string/
    /// </summary>
    /// <remarks>
    /// **الوصف:**
    /// اكتب دالة تعكس سلسلة نصية (string). يجب أن يتم تعديل سلسلة الإدخال في مكانها (in-place) بذاكرة إضافية O(1).
    /// يمكنك افتراض أن جميع الأحرف هي أحرف ASCII قابلة للطباعة.
    /// 
    /// **مثال 1:**
    /// الإدخال: s = ["h","e","l","l","o"]
    /// الإخراج: ["o","l","l","e","h"]
    /// 
    /// **مثال 2:**
    /// الإدخال: s = ["H","a","n","n","a","h"]
    /// الإخراج: ["h","a","n","n","a","H"]
    /// </remarks>
    public class ReverseStringSolution
    {
        /// <summary>
        /// تعكس سلسلة نصية من الأحرف في مكانها.
        /// </summary>
        /// <param name="s">مصفوفة الأحرف لتعكسها.</param>
        public void ReverseString(char[] s)
        {
            // مؤشر يشير إلى بداية المصفوفة.
            int left = 0;
            // مؤشر يشير إلى نهاية المصفوفة.
            int right = s.Length - 1;

            // نكرر العملية طالما أن المؤشر الأيسر أقل من المؤشر الأيمن.
            while (left < right)
            {
                // نبادل الحرف عند المؤشر الأيسر مع الحرف عند المؤشر الأيمن.
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;

                // نحرك المؤشر الأيسر خطوة واحدة إلى اليمين.
                left++;
                // نحرك المؤشر الأيمن خطوة واحدة إلى اليسار.
                right--;
            }
        }
    }
}
