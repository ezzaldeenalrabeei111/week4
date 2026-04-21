using System;
using LibraryManagementSystem.Core;

namespace LibraryManagementSystem.Core
{
    /// <summary>
    /// كلاس يمثل قرص DVD في المكتبة.
    /// يرث من LibraryItem ويضيف خاصية مدة العرض (Duration).
    /// يوضح تطبيق مبدأ الفتح/الغلق (OCP) حيث يمكن إضافة أنواع جديدة دون تعديل الكلاسات الموجودة.
    /// </summary>
    public class DVD : LibraryItem
    {
        public int DurationMinutes { get; private set; }

        /// <summary>
        /// منشئ الكلاس DVD.
        /// </summary>
        /// <param name="title">عنوان الـ DVD.</param>
        /// <param name="director">المخرج.</param>
        /// <param name="isbn">رقم ISBN للـ DVD.</param>
        /// <param name="durationMinutes">مدة عرض الـ DVD بالدقائق.</param>
        public DVD(string title, string director, string isbn, int durationMinutes)
            : base(title, director, isbn)
        {
            if (durationMinutes <= 0)
            {
                throw new ArgumentException("Duration must be positive.");
            }
            DurationMinutes = durationMinutes;
        }

        /// <summary>
        /// عرض معلومات الـ DVD، مع إعادة تعريف (override) لدالة DisplayInfo.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"DVD: \"{Title}\" by {Author}, ISBN: {ISBN}, Duration: {DurationMinutes} mins");
        }
    }
}
