using System;

namespace ISPRefactoredInterfaces.Core
{
    /// <summary>
    /// واجهة لوظيفة المسح الضوئي فقط.
    /// تطبق مبدأ فصل الواجهات (ISP) لتجنب الواجهات الضخمة.
    /// </summary>
    public interface IScanner
    {
        /// <summary>
        /// دالة المسح الضوئي.
        /// </summary>
        /// <param name="document">المستند المراد مسحه ضوئياً.</param>
        /// <returns>نسخة رقمية من المستند.</returns>
        string Scan(string document);
    }
}
