using System;
using OCPDiscountSystem.Core;

namespace OCPDiscountSystem.Discounts
{
    /// <summary>
    /// كلاس يمثل خصماً موسمياً (مثلاً خصم 10%).
    /// يطبق واجهة IDiscount.
    /// </summary>
    public class SeasonalDiscount : IDiscount
    {
        private readonly decimal _discountPercentage;

        /// <summary>
        /// منشئ الكلاس SeasonalDiscount.
        /// </summary>
        /// <param name="discountPercentage">نسبة الخصم الموسمية (مثلاً 0.10 لـ 10%).</param>
        public SeasonalDiscount(decimal discountPercentage)
        {
            if (discountPercentage < 0 || discountPercentage > 1)
            {
                throw new ArgumentOutOfRangeException("discountPercentage", "Discount percentage must be between 0 and 1.");
            }
            _discountPercentage = discountPercentage;
        }

        /// <summary>
        /// حساب قيمة الخصم الموسمي.
        /// </summary>
        /// <param name="originalPrice">السعر الأصلي.</param>
        /// <returns>قيمة الخصم.</returns>
        public decimal CalculateDiscount(decimal originalPrice)
        {
            return originalPrice * _discountPercentage;
        }
    }
}
