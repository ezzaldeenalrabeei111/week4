using System;

namespace OCPDiscountSystem.Core
{
    /// <summary>
    /// واجهة IDiscount تحدد العقد لحساب الخصومات.
    /// تتبع مبدأ فصل الواجهات (ISP) ومبدأ الفتح/الغلق (OCP).
    /// </summary>
    public interface IDiscount
    {
        /// <summary>
        /// حساب قيمة الخصم بناءً على السعر الأصلي.
        /// </summary>
        /// <param name="originalPrice">السعر الأصلي للمنتج أو الخدمة.</param>
        /// <returns>قيمة الخصم التي سيتم تطبيقها.</returns>
        decimal CalculateDiscount(decimal originalPrice);
    }
}
