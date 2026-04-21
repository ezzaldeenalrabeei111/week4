using System;

namespace ISPRefactoredInterfaces.Core
{
    /// <summary>
    /// واجهة لوظيفة الفاكس فقط.
    /// تطبق مبدأ فصل الواجهات (ISP) لتجنب الواجهات الضخمة.
    /// </summary>
    public interface IFax
    {
        /// <summary>
        /// دالة إرسال الفاكس.
        /// </summary>
        /// <param name="document">المستند المراد إرساله بالفاكس.</param>
        /// <param name="phoneNumber">رقم الهاتف لإرسال الفاكس إليه.</param>
        void Fax(string document, string phoneNumber);
    }
}
