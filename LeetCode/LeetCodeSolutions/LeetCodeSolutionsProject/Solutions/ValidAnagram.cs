using System;
using System.Linq;
using System.Collections.Generic;

namespace LeetCodeSolutions
{
    /// <summary>
    /// حل مسألة LeetCode رقم 242: Valid Anagram
    /// رابط المسألة: https://leetcode.com/problems/valid-anagram/
    /// </summary>
    /// <remarks>
    /// **الوصف:**
    /// بالنظر إلى سلسلتين نصيتين `s` و `t`، أعد `true` إذا كانت `t` هي Anagram لـ `s`، وإلا `false`.
    /// Anagram هي كلمة أو عبارة تتكون عن طريق إعادة ترتيب أحرف كلمة أو عبارة أخرى،
    /// عادة ما تستخدم جميع الأحرف الأصلية مرة واحدة بالضبط.
    /// 
    /// **مثال 1:**
    /// الإدخال: s = "anagram", t = "nagaram"
    /// الإخراج: true
    /// 
    /// **مثال 2:**
    /// الإدخال: s = "rat", t = "car"
    /// الإخراج: false
    /// </remarks>
    public class ValidAnagramSolution
    {
        /// <summary>
        /// يتحقق مما إذا كانت السلسلة النصية `t` هي Anagram للسلسلة النصية `s`.
        /// </summary>
        /// <param name="s">السلسلة النصية الأولى.</param>
        /// <param name="t">السلسلة النصية الثانية.</param>
        /// <returns>true إذا كانت `t` هي Anagram لـ `s`، وإلا false.</returns>
        public bool IsAnagram(string s, string t)
        {
            // إذا كان طول السلسلتين النصيتين مختلفاً، فلا يمكن أن تكونا Anagram لبعضهما البعض.
            if (s.Length != t.Length)
            {
                return false;
            }

            // نستخدم مصفوفة تردد (frequency array) لتخزين عدد مرات ظهور كل حرف.
            // بما أن الأحرف هي أحرف إنجليزية صغيرة، فإن حجم المصفوفة سيكون 26.
            int[] charCounts = new int[26];

            // نمر على السلسلة النصية الأولى `s` ونزيد عداد كل حرف.
            foreach (char c in s)
            {
                charCounts[c - 'a']++;
            }

            // نمر على السلسلة النصية الثانية `t` وننقص عداد كل حرف.
            foreach (char c in t)
            {
                charCounts[c - 'a']--;
            }

            // نتحقق مما إذا كانت جميع العدادات في المصفوفة تساوي صفراً.
            // إذا كانت كذلك، فهذا يعني أن كل حرف ظهر نفس العدد من المرات في كلتا السلسلتين.
            foreach (int count in charCounts)
            {
                if (count != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
