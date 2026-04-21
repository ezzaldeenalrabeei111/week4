using System;
using OCPDiscountSystem.Core;
using OCPDiscountSystem.Discounts;
using OCPDiscountSystem.Services;

namespace OCPDiscountSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- OCP Discount System Demo ---");

            decimal originalPrice = 100m; // سعر المنتج الأصلي
            Console.WriteLine($"\nOriginal Price: {originalPrice:C}");

            // 1. تطبيق خصم موسمي (10%)
            IDiscount seasonalDiscount = new SeasonalDiscount(0.10m);
            DiscountCalculator seasonalCalculator = new DiscountCalculator(seasonalDiscount);
            decimal priceAfterSeasonalDiscount = seasonalCalculator.CalculateFinalPrice(originalPrice);
            Console.WriteLine($"Price after Seasonal Discount (10%): {priceAfterSeasonalDiscount:C}");

            // 2. تطبيق خصم الأعضاء (خصم ثابت 5 وحدات نقدية)
            IDiscount memberDiscount = new MemberDiscount(5m);
            DiscountCalculator memberCalculator = new DiscountCalculator(memberDiscount);
            decimal priceAfterMemberDiscount = memberCalculator.CalculateFinalPrice(originalPrice);
            Console.WriteLine($"Price after Member Discount (5 units): {priceAfterMemberDiscount:C}");

            // 3. تطبيق خصم كبار الشخصيات (20%)
            IDiscount vipDiscount = new VipDiscount(0.20m);
            DiscountCalculator vipCalculator = new DiscountCalculator(vipDiscount);
            decimal priceAfterVipDiscount = vipCalculator.CalculateFinalPrice(originalPrice);
            Console.WriteLine($"Price after VIP Discount (20%): {priceAfterVipDiscount:C}");

            // مثال: خصم عضو على سعر منخفض
            decimal lowPrice = 3m;
            Console.WriteLine($"\nOriginal Low Price: {lowPrice:C}");
            DiscountCalculator lowPriceMemberCalculator = new DiscountCalculator(memberDiscount);
            decimal priceAfterLowPriceMemberDiscount = lowPriceMemberCalculator.CalculateFinalPrice(lowPrice);
            Console.WriteLine($"Price after Member Discount (5 units) on low price: {priceAfterLowPriceMemberDiscount:C}");

            Console.WriteLine("\n--- Demonstrating OCP: Adding a new discount type ---");
            // تخيل أننا أضفنا نوع خصم جديد (مثلاً خصم للطلاب) دون تعديل DiscountCalculator
            // StudentDiscount.cs (ملف جديد)
            // public class StudentDiscount : IDiscount
            // {
            //     public decimal CalculateDiscount(decimal originalPrice) { return originalPrice * 0.15m; }
            // }

            // يمكننا استخدامه مباشرة:
            // IDiscount studentDiscount = new StudentDiscount();
            // DiscountCalculator studentCalculator = new DiscountCalculator(studentDiscount);
            // Console.WriteLine($"Price after Student Discount (15%): {studentCalculator.CalculateFinalPrice(originalPrice):C}");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
