using System;
using System.Collections.Generic;
using DIPReportGenerator.Core;
using DIPReportGenerator.DataSources;
using DIPReportGenerator.Reports;

namespace DIPReportGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- DIP Report Generator Demo ---");

            // 1. إنشاء مصادر البيانات الملموسة (Low-level modules)
            // هذه هي الخدمات الفعلية التي تجلب البيانات.
            IDataSource sqlDataSource = new SqlDataSource("Server=myDB;Database=Sales");
            IDataSource jsonDataSource = new JsonDataSource("data.json");
            IDataSource apiDataSource = new ApiDataSource("https://api.example.com/users");

            Console.WriteLine("\n--- Generating Report from SQL Data Source ---");
            // 2. حقن التبعية (Dependency Injection)
            // ReportGenerator (High-level module) يعتمد على التجريد (IDataSource)
            // ولا يعرف شيئاً عن التنفيذات الملموسة (SqlDataSource, JsonDataSource, ApiDataSource).
            ReportGenerator sqlReport = new ReportGenerator(sqlDataSource);
            sqlReport.GenerateReport();

            Console.WriteLine("\n--- Generating Report from JSON Data Source ---");
            ReportGenerator jsonReport = new ReportGenerator(jsonDataSource);
            jsonReport.GenerateReport();

            Console.WriteLine("\n--- Generating Report from API Data Source ---");
            ReportGenerator apiReport = new ReportGenerator(apiDataSource);
            apiReport.GenerateReport();

            Console.WriteLine("\n--- End of DIP Report Generator Demo ---");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
