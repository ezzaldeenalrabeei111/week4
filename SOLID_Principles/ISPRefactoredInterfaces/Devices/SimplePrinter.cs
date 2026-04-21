using System;
using ISPRefactoredInterfaces.Core;

namespace ISPRefactoredInterfaces.Devices
{
    /// <summary>
    /// كلاس يمثل طابعة بسيطة. تطبق فقط واجهة IPrinter.
    /// يوضح كيف أن الكلاس لا يضطر لتنفيذ واجهات لا يحتاجها (تطبيق ISP).
    /// </summary>
    public class SimplePrinter : IPrinter
    {
        public string Name { get; private set; }

        public SimplePrinter(string name)
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
    }
}
