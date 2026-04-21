using System;
using System.Collections.Generic;
using DIPReportGenerator.Core;

namespace DIPReportGenerator.DataSources
{
    /// <summary>
    /// مصدر بيانات يمثل جلب البيانات من ملف JSON.
    /// يطبق واجهة IDataSource.
    /// </summary>
    public class JsonDataSource : IDataSource
    {
        private readonly string _jsonFilePath;

        public JsonDataSource(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        /// <summary>
        /// جلب البيانات من ملف JSON (محاكاة).
        /// </summary>
        /// <returns>قائمة من القواميس تمثل البيانات.</returns>
        public List<Dictionary<string, string>> GetData()
        {
            Console.WriteLine($"JsonDataSource: Reading data from JSON file: {_jsonFilePath}");
            // محاكاة جلب البيانات من ملف JSON
            return new List<Dictionary<string, string>>
            {
                new Dictionary<string, string> { { "OrderID", "101" }, { "Customer", "Ali" }, { "Amount", "250" } },
                new Dictionary<string, string> { { "OrderID", "102" }, { "Customer", "Fatima" }, { "Amount", "300" } }
            };
        }
    }
}
