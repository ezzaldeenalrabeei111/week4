using System;
using OCPDiscountSystem.Core;

namespace OCPDiscountSystem.Services
{
    /// <summary>
    /// كلاس مسؤول عن حساب الخصم بناءً على استراتيجية خصم معينة.
    /// يطبق مبدأ الفتح/الغلق (OCP) من خلال الاعتماد على واجهة IDiscount.
    /// </summary>
    public class DiscountCalculator
    {
        private readonly IDiscount _discountStrategy;

        /// <summary>
        /// منشئ الكلاس DiscountCalculator.
        /// يعتمد على واجهة IDiscount، مما يسمح بتمرير أي نوع خصم يطبق هذه الواجهة.
        /// </summary>
        /// <param name="discountStrategy">استراتيجية الخصم المراد تطبيقها.</param>
        public DiscountCalculator(IDiscount discountStrategy)
        {
            if (discountStrategy == null)
            {
                throw new ArgumentNullException("discountStrategy", "Discount strategy cannot be null.");
            }
            _discountStrategy = discountStrategy;
        }

        /// <summary>
        /// حساب السعر النهائي بعد تطبيق الخصم.
        /// </summary>
        /// <param name="originalPrice">السعر الأصلي للمنتج.</param>
        /// <returns>السعر بعد تطبيق الخصم.</returns>
        public decimal CalculateFinalPrice(decimal originalPrice)
        {
            if (originalPrice < 0)
            {
                throw new ArgumentOutOfRangeException("originalPrice", "Original price cannot be negative.");
            }

            decimal discountAmount = _discountStrategy.CalculateDiscount(originalPrice);
            decimal finalPrice = originalPrice - discountAmount;

            // التأكد من أن السعر النهائي لا يقل عن الصفر
            return Math.Max(0, finalPrice);
        }
    }
}
