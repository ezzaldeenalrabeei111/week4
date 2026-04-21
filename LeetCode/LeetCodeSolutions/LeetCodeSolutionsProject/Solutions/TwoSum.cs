using System;
using System.Collections.Generic;

namespace LeetCodeSolutions
{
    /// <summary>
    /// حل مسألة LeetCode رقم 1: Two Sum
    /// رابط المسألة: https://leetcode.com/problems/two-sum/
    /// </summary>
    /// <remarks>
    /// **الوصف:**
    /// بالنظر إلى مصفوفة من الأعداد الصحيحة `nums` وعدد صحيح مستهدف `target`،
    /// أعد فهارس العددين بحيث يجمعان إلى `target`.
    /// يمكنك افتراض أن كل إدخال سيكون له حل واحد بالضبط، ولا يجوز لك استخدام نفس العنصر مرتين.
    /// يمكنك إرجاع الإجابة بأي ترتيب.
    /// 
    /// **مثال 1:**
    /// الإدخال: nums = [2,7,11,15], target = 9
    /// الإخراج: [0,1]
    /// الشرح: لأن nums[0] + nums[1] == 9، نرجع [0, 1].
    /// 
    /// **مثال 2:**
    /// الإدخال: nums = [3,2,4], target = 6
    /// الإخراج: [1,2]
    /// 
    /// **مثال 3:**
    /// الإدخال: nums = [3,3], target = 6
    /// الإخراج: [0,1]
    /// </remarks>
    public class TwoSumSolution
    {
        /// <summary>
        /// يجد فهارس العددين في المصفوفة اللذين يجمعان إلى العدد المستهدف.
        /// </summary>
        /// <param name="nums">المصفوفة من الأعداد الصحيحة.</param>
        /// <param name="target">العدد المستهدف.</param>
        /// <returns>مصفوفة تحتوي على فهارس العددين.</returns>
        public int[] TwoSum(int[] nums, int target)
        {
            // نستخدم HashMap (أو Dictionary في C#) لتخزين الأرقام التي رأيناها وفهارسها.
            // هذا يسمح لنا بالبحث عن المكمل (complement) في وقت O(1) في المتوسط.
            // المفتاح: الرقم، القيمة: الفهرس.
            Dictionary<int, int> numMap = new Dictionary<int, int>();

            // نمر على كل رقم في المصفوفة مرة واحدة.
            for (int i = 0; i < nums.Length; i++)
            {
                int currentNum = nums[i];
                // نحسب المكمل: الرقم الذي نحتاجه لكي نصل إلى الهدف (target).
                int complement = target - currentNum;

                // نتحقق مما إذا كان المكمل موجوداً بالفعل في الـ HashMap.
                // إذا كان موجوداً، فهذا يعني أننا وجدنا العددين المطلوبين.
                if (numMap.ContainsKey(complement))
                {
                    // نرجع فهرس المكمل والفهرس الحالي.
                    return new int[] { numMap[complement], i };
                }

                // إذا لم يكن المكمل موجوداً، نضيف الرقم الحالي وفهرسه إلى الـ HashMap.
                // هذا الرقم قد يكون مكملاً لرقم آخر لاحقاً في المصفوفة.
                // نتحقق أولاً إذا كان الرقم الحالي موجوداً بالفعل لتجنب الأخطاء إذا كانت هناك أرقام مكررة
                // ولكن المسألة تفترض وجود حل واحد فقط، لذا يمكننا إضافته مباشرة.
                if (!numMap.ContainsKey(currentNum))
                {
                    numMap.Add(currentNum, i);
                }
            }

            // إذا لم يتم العثور على حل (على الرغم من أن المسألة تفترض وجود حل واحد دائماً).
            throw new ArgumentException("No two sum solution");
        }
    }
}
