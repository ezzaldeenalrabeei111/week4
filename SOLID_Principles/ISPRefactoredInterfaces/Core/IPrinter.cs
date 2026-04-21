using System;

namespace ISPRefactoredInterfaces.Core
{
    /// <summary>
    /// واجهة لوظيفة الطباعة فقط.
    /// تطبق مبدأ فصل الواجهات (ISP) لتجنب الواجهات الضخمة.
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// دالة الطباعة.
        /// </summary>
        /// <param name="document">المستند المراد طباعته.</param>
        void Print(string document);
    }
}
