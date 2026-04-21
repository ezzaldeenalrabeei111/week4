using System;
using System.Collections.Generic;
using DIPReportGenerator.Core;

namespace DIPReportGenerator.Reports
{
    /// <summary>
    /// كلاس ReportGenerator مسؤول عن توليد التقارير.
    /// يعتمد على التجريد (IDataSource) بدلاً من التنفيذات الملموسة (تطبيق DIP).
    /// </summary>
    public class ReportGenerator
    {
        private readonly IDataSource _dataSource;

        /// <summary>
        /// Constructor يقوم بحقن التبعية (IDataSource).
        /// </summary>
        /// <param name="dataSource">مصدر البيانات الذي سيتم استخدامه لتوليد التقرير.</param>
        public ReportGenerator(IDataSource dataSource)
        {
            _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));
            Console.WriteLine($"ReportGenerator initialized with data source: {_dataSource.GetType().Name}");
        }

        /// <summary>
        /// توليد التقرير بناءً على البيانات المسترجعة من مصدر البيانات.
        /// </summary>
        public void GenerateReport()
        {
            Console.WriteLine("\n--- Generating Report ---");
            List<Dictionary<string, string>> data = _dataSource.GetData();

            if (data == null || data.Count == 0)
            {
                Console.WriteLine("No data available to generate report.");
                return;
            }

            foreach (var row in data)
            {
                foreach (var entry in row)
                {
                    Console.Write($"{entry.Key}: {entry.Value}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("--- Report Generated Successfully ---");
        }
    }
}
