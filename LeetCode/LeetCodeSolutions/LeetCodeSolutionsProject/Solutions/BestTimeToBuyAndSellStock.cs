using System;

namespace LeetCodeSolutions
{
    /// <summary>
    /// حل مسألة LeetCode رقم 121: Best Time to Buy and Sell Stock
    /// رابط المسألة: https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
    /// </summary>
    /// <remarks>
    /// **الوصف:**
    /// بالنظر إلى مصفوفة `prices` حيث `prices[i]` هو سعر سهم معين في اليوم `i`.
    /// تريد تعظيم ربحك باختيار يوم واحد لشراء سهم واحد واختيار يوم مختلف في المستقبل لبيع هذا السهم.
    /// أعد أقصى ربح يمكنك تحقيقه من هذه الصفقة. إذا لم تتمكن من تحقيق أي ربح، أعد 0.
    /// 
    /// **مثال 1:**
    /// الإدخال: prices = [7,1,5,3,6,4]
    /// الإخراج: 5
    /// الشرح: اشترِ في اليوم 2 (السعر = 1) وبع في اليوم 5 (السعر = 6)، الربح = 6-1 = 5.
    /// لاحظ أنه لا يمكنك الشراء في اليوم 2 والبيع في اليوم 1 لأنك يجب أن تشتري قبل البيع.
    /// 
    /// **مثال 2:**
    /// الإدخال: prices = [7,6,4,3,1]
    /// الإخراج: 0
    /// الشرح: في هذه الحالة، لا يتم تحقيق أي صفقة، وبالتالي أقصى ربح = 0.
    /// </remarks>
    public class BestTimeToBuyAndSellStockSolution
    {
        /// <summary>
        /// يحسب أقصى ربح يمكن تحقيقه من شراء وبيع سهم واحد.
        /// </summary>
        /// <param name="prices">مصفوفة أسعار الأسهم.</param>
        /// <returns>أقصى ربح ممكن.</returns>
        public int MaxProfit(int[] prices)
        {
            // إذا كانت المصفوفة فارغة أو تحتوي على عنصر واحد فقط، لا يمكن تحقيق ربح.
            if (prices == null || prices.Length <= 1)
            {
                return 0;
            }

            // minPrice لتتبع أقل سعر شراء رأيناه حتى الآن.
            // maxProfit لتتبع أقصى ربح تم تحقيقه حتى الآن.
            int minPrice = prices[0];
            int maxProfit = 0;

            // نمر على الأسعار بدءاً من اليوم الثاني.
            for (int i = 1; i < prices.Length; i++)
            {
                // إذا كان السعر الحالي أقل من minPrice، نحدث minPrice.
                // هذا يعني أننا وجدنا فرصة شراء أفضل.
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                }
                else
                {
                    // إذا كان السعر الحالي أكبر من minPrice، نحسب الربح المحتمل.
                    // ونقارنه بـ maxProfit لتحديث أقصى ربح.
                    maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
                }
            }

            return maxProfit;
        }
    }
}
