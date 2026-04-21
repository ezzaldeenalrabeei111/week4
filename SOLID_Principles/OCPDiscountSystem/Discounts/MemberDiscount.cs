using System;
using OCPDiscountSystem.Core;

namespace OCPDiscountSystem.Discounts
{
    /// <summary>
    /// كلاس يمثل خصماً خاصاً بالأعضاء (مثلاً خصم ثابت 5 وحدات نقدية).
    /// يطبق واجهة IDiscount.
    /// </summary>
    public class MemberDiscount : IDiscount
    {
        private readonly decimal _fixedDiscountAmount;

        /// <summary>
        /// منشئ الكلاس MemberDiscount.
        /// </summary>
        /// <param name="fixedDiscountAmount">قيمة الخصم الثابتة للأعضاء.</param>
        public MemberDiscount(decimal fixedDiscountAmount)
        {
            if (fixedDiscountAmount < 0)
            {
                throw new ArgumentOutOfRangeException("fixedDiscountAmount", "Fixed discount amount cannot be negative.");
            }
            _fixedDiscountAmount = fixedDiscountAmount;
        }

        /// <summary>
        /// حساب قيمة الخصم الخاص بالأعضاء.
        /// </summary>
        /// <param name="originalPrice">السعر الأصلي.</param>
        /// <returns>قيمة الخصم.</returns>
        public decimal CalculateDiscount(decimal originalPrice)
        {
            // لا يمكن أن يكون الخصم أكبر من السعر الأصلي
            return Math.Min(originalPrice, _fixedDiscountAmount);
        }
    }
}
