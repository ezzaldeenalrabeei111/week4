using System;
using ISPRefactoredInterfaces.Core;

namespace ISPRefactoredInterfaces.Devices
{
    /// <summary>
    /// كلاس يمثل طابعة متعددة الوظائف. تطبق واجهات IPrinter, IScanner, و IFax.
    /// يوضح كيف يمكن لجهاز واحد أن يطبق عدة واجهات متخصصة (تطبيق ISP).
    /// </summary>
    public class MultiFunctionPrinter : IPrinter, IScanner, IFax
    {
        public string Name { get; private set; }

        public MultiFunctionPrinter(string name)
        {
            Name = name;
        }

        /// <summary>
        /// تنفيذ دالة الطباعة.
        /// </summary>
        /// <param name="document">المستند المراد طباعته.</param>
        public void Print(string document)
        {
            Console.WriteLine($"{Name} is printing: {document}");
        }

        /// <summary>
        /// تنفيذ دالة المسح الضوئي.
        /// </summary>
        /// <param name="document">المستند المراد مسحه ضوئياً.</param>
        /// <returns>نسخة رقمية من المستند.</returns>
        public string Scan(string document)
        {
            Console.WriteLine($"{Name} is scanning: {document}");
            return $"Scanned_{document}";
        }

        /// <summary>
        /// تنفيذ دالة إرسال الفاكس.
        /// </summary>
        /// <param name="document">المستند المراد إرساله بالفاكس.</param>
        /// <param name="phoneNumber">رقم الهاتف لإرسال الفاكس إليه.</param>
        public void Fax(string document, string phoneNumber)
        {
            Console.WriteLine($"{Name} is faxing: {document} to {phoneNumber}");
        }
    }
}
