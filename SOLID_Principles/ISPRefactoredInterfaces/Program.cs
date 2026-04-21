using System;
using System.Collections.Generic;
using ISPRefactoredInterfaces.Core;
using ISPRefactoredInterfaces.Devices;

namespace ISPRefactoredInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- ISP Refactored Interfaces Demo ---");

            // إنشاء طابعة بسيطة (تطبق IPrinter و IDevice فقط)
            SimplePrinter simplePrinter = new SimplePrinter("HP LaserJet 1000");
            simplePrinter.Print("My important document");
            // simplePrinter.Scan("document"); // هذا السطر سيسبب خطأ في الكومبايلر لأن SimplePrinter لا يطبق IScanner
            // simplePrinter.Fax("document", "123456789"); // هذا السطر سيسبب خطأ في الكومبايلر لأن SimplePrinter لا يطبق IFax

            Console.WriteLine("\n----------------------------------------");

            // إنشاء طابعة متعددة الوظائف (تطبق IPrinter, IScanner, IFax, و IDevice)
            MultiFunctionPrinter multiPrinter = new MultiFunctionPrinter("Canon Multi-Function Pro");
            multiPrinter.Print("Another document");
            string scannedDoc = multiPrinter.Scan("Image.jpg");
            Console.WriteLine($"Scanned document: {scannedDoc}");
            multiPrinter.Fax("Contract.pdf", "+1-555-1234");

            Console.WriteLine("\n----------------------------------------");

            // توضيح مرونة ISP:
            // يمكننا تمرير أي كائن يطبق IPrinter إلى دالة تتوقع IPrinter
            ProcessPrinter(simplePrinter);
            ProcessPrinter(multiPrinter);

            // يمكننا تمرير أي كائن يطبق IScanner إلى دالة تتوقع IScanner
            ProcessScanner(multiPrinter);

            // يمكننا تمرير أي كائن يطبق IFax إلى دالة تتوقع IFax
            ProcessFax(multiPrinter);

            Console.WriteLine("\n--- End of Demo ---");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        /// <summary>
        /// دالة مساعدة تقبل أي كائن يطبق واجهة IPrinter.
        /// </summary>
        static void ProcessPrinter(IPrinter printer)
        {
            // استخدام التحقق الآمن (is) للوصول إلى الاسم إذا كان يطبق IDevice
            if (printer is IDevice device)
            {
                Console.WriteLine($"\nProcessing printer: {device.Name}");
            }
            else
            {
                Console.WriteLine($"\nProcessing an unknown printer type.");
            }
            printer.Print("Test Page");
        }

        /// <summary>
        /// دالة مساعدة تقبل أي كائن يطبق واجهة IScanner.
        /// </summary>
        static void ProcessScanner(IScanner scanner)
        {
            if (scanner is IDevice device)
            {
                Console.WriteLine($"\nProcessing scanner: {device.Name}");
            }
            else
            {
                Console.WriteLine($"\nProcessing an unknown scanner type.");
            }
            scanner.Scan("Receipt.png");
        }

        /// <summary>
        /// دالة مساعدة تقبل أي كائن يطبق واجهة IFax.
        /// </summary>
        static void ProcessFax(IFax faxMachine)
        {
            if (faxMachine is IDevice device)
            {
                Console.WriteLine($"\nProcessing fax machine: {device.Name}");
            }
            else
            {
                Console.WriteLine($"\nProcessing an unknown fax machine type.");
            }
            faxMachine.Fax("Report.doc", "+1-555-9876");
        }
    }
}
