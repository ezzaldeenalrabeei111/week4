using System;
using LibraryManagementSystem.Core;

namespace LibraryManagementSystem.Core
{
    /// <summary>
    /// كلاس يمثل مجلة في المكتبة.
    /// يرث من LibraryItem ويضيف خاصية رقم العدد.
    /// يوضح تطبيق مبدأ الفتح/الغلق (OCP) حيث يمكن إضافة أنواع جديدة دون تعديل الكلاسات الموجودة.
    /// </summary>
    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; private set; }

        /// <summary>
        /// منشئ الكلاس Magazine.
        /// </summary>
        /// <param name="title">عنوان المجلة.</param>
        /// <param name="publisher">الناشر.</param>
        /// <param name="isbn">رقم ISBN للمجلة.</param>
        /// <param name="issueNumber">رقم العدد للمجلة.</param>
        public Magazine(string title, string publisher, string isbn, int issueNumber)
            : base(title, publisher, isbn)
        {
            if (issueNumber <= 0)
            {
                throw new ArgumentException("Issue number must be positive.");
            }
            IssueNumber = issueNumber;
        }

        /// <summary>
        /// عرض معلومات المجلة، مع إعادة تعريف (override) لدالة DisplayInfo.
        /// </summary>
        public override void DisplayInfo()
        {
            Console.WriteLine($"Magazine: \"{Title}\" by {Author}, ISBN: {ISBN}, Issue: {IssueNumber}");
        }
    }
}
