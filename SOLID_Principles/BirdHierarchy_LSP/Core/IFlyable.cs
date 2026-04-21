using System;

namespace BirdHierarchy.Core
{
    /// <summary>
    /// واجهة للطيور التي تستطيع الطيران.
    /// تساعد في تطبيق مبدأ استبدال ليسكوف (LSP) بفصل سلوك الطيران عن الكلاس الأساسي Bird.
    /// </summary>
    public interface IFlyable
    {
        /// <summary>
        /// دالة الطيران.
        /// </summary>
        void Fly();
    }
}
