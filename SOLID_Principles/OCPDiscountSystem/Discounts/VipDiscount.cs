using System;
using OCPDiscountSystem.Core;

namespace OCPDiscountSystem.Discounts
{
    /// <summary>
    /// كلاس يمثل خصماً خاصاً بكبار الشخصيات (VIP) (مثلاً خصم 20% على السعر الأصلي).
    /// يطبق واجهة IDiscount.
    /// </summary>
    public class VipDiscount : IDiscount
    {
        private readonly decimal _vipDiscountPercentage;

        /// <summary>
        /// منشئ الكلاس VipDiscount.
        /// </summary>
        /// <param name="vipDiscountPercentage">نسبة الخصم لكبار الشخصيات (مثلاً 0.20 لـ 20%).</param>
        public VipDiscount(decimal vipDiscountPercentage)
        {
            if (vipDiscountPercentage < 0 || vipDiscountPercentage > 1)
            {
                throw new ArgumentOutOfRangeException("vipDiscountPercentage", "VIP discount percentage must be between 0 and 1.");
            }
            _vipDiscountPercentage = vipDiscountPercentage;
        }

        /// <summary>
        /// حساب قيمة الخصم الخاص بكبار الشخصيات.
        /// </summary>
        /// <param name="originalPrice">السعر الأصلي.</param>
        /// <returns>قيمة الخصم.</returns>
        public decimal CalculateDiscount(decimal originalPrice)
        {
            return originalPrice * _vipDiscountPercentage;
        }
    }
}
