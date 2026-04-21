using System;

namespace LeetCodeSolutions
{
    /// <summary>
    /// حل مسألة LeetCode رقم 9: Palindrome Number
    /// رابط المسألة: https://leetcode.com/problems/palindrome-number/
    /// </summary>
    /// <remarks>
    /// **الوصف:**
    /// بالنظر إلى عدد صحيح `x`، أعد `true` إذا كان `x` هو عدد Palindrome.
    /// العدد Palindrome هو عدد يقرأ نفسه إلى الأمام والخلف.
    /// على سبيل المثال، 121 هو Palindrome بينما 123 ليس كذلك.
    /// 
    /// **مثال 1:**
    /// الإدخال: x = 121
    /// الإخراج: true
    /// 
    /// **مثال 2:**
    /// الإدخال: x = -121
    /// الإخراج: false
    /// الشرح: من اليسار إلى اليمين، يقرأ -121. من اليمين إلى اليسار، يصبح 121-. وبالتالي فهو ليس Palindrome.
    /// 
    /// **مثال 3:**
    /// الإدخال: x = 10
    /// الإخراج: false
    /// الشرح: من اليمين إلى اليسار، يقرأ 01. وبالتالي فهو ليس Palindrome.
    /// 
    /// **تحدي:** هل يمكنك حلها دون تحويل العدد إلى سلسلة نصية (string)؟
    /// </remarks>
    public class PalindromeNumberSolution
    {
        /// <summary>
        /// يتحقق مما إذا كان العدد الصحيح المعطى هو Palindrome.
        /// </summary>
        /// <param name="x">العدد الصحيح للتحقق.</param>
        /// <returns>true إذا كان العدد Palindrome، وإلا false.</returns>
        public bool IsPalindrome(int x)
        {
            // 1. حالات الحافة (Edge Cases):
            // - إذا كان x سالباً، فإنه لا يمكن أن يكون Palindrome (لأن علامة السالب لا تتكرر).
            // - إذا كان x ينتهي بصفر (باستثناء الصفر نفسه)، فإنه لا يمكن أن يكون Palindrome.
            //   مثال: 10، 200. إذا كان العدد ينتهي بصفر، فيجب أن يبدأ بصفر ليكون Palindrome، والعدد الوحيد الذي يبدأ بصفر هو الصفر نفسه.
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            int reversedNumber = 0;
            // نكرر العملية طالما أن العدد الأصلي أكبر من العدد المعكوس.
            // في كل تكرار، نأخذ الرقم الأخير من x ونضيفه إلى reversedNumber.
            while (x > reversedNumber)
            {
                // نحصل على الرقم الأخير من x
                int digit = x % 10;
                // نضيف الرقم الأخير إلى reversedNumber ونحركه خانة واحدة لليسار (نضربه في 10)
                reversedNumber = reversedNumber * 10 + digit;
                // نزيل الرقم الأخير من x
                x /= 10;
            }

            // عند انتهاء الحلقة، لدينا حالتان:
            // 1. إذا كان طول العدد الأصلي زوجياً، فإن x و reversedNumber سيكونان متساويين تماماً.
            //    مثال: x = 1221. في النهاية، x = 12, reversedNumber = 12.
            // 2. إذا كان طول العدد الأصلي فردياً، فإن x سيكون الرقم الأوسط، و reversedNumber سيكون نصف العدد المعكوس.
            //    مثال: x = 121. في النهاية، x = 1, reversedNumber = 12. يجب أن نقارن x بـ reversedNumber / 10.
            //    (reversedNumber / 10) يتجاهل الرقم الأوسط الذي لا يؤثر على كونه Palindrome.
            return x == reversedNumber || x == reversedNumber / 10;
        }
    }
}
