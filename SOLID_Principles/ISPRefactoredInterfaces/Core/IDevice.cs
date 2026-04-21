using System;

namespace ISPRefactoredInterfaces.Core
{
    /// <summary>
    /// واجهة أساسية للأجهزة التي تحتوي على اسم.
    /// تساعد في الوصول إلى اسم الجهاز بشكل عام دون الحاجة للتحويل إلى كلاسات ملموسة.
    /// </summary>
    public interface IDevice
    {
        /// <summary>
        /// اسم الجهاز.
        /// </summary>
        string Name { get; }
    }
}
