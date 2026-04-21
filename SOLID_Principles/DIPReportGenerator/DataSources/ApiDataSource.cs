using System;
using System.Collections.Generic;
using DIPReportGenerator.Core;

namespace DIPReportGenerator.DataSources
{
    /// <summary>
    /// مصدر بيانات يمثل جلب البيانات من واجهة برمجة تطبيقات (API).
    /// يطبق واجهة IDataSource.
    /// </summary>
    public class ApiDataSource : IDataSource
    {
        private readonly string _apiUrl;

        public ApiDataSource(string apiUrl)
        {
            _apiUrl = apiUrl;
        }

        /// <summary>
        /// جلب البيانات من API (محاكاة).
        /// </summary>
        /// <returns>قائمة من القواميس تمثل البيانات.</returns>
        public List<Dictionary<string, string>> GetData()
        {
            Console.WriteLine($"ApiDataSource: Fetching data from API: {_apiUrl}");
            // محاكاة جلب البيانات من API
            return new List<Dictionary<string, string>>
            {
                new Dictionary<string, string> { { "UserID", "A1" }, { "Username", "Ahmed" }, { "Status", "Active" } },
                new Dictionary<string, string> { { "UserID", "B2" }, { "Username", "Sara" }, { "Status", "Inactive" } }
            };
        }
    }
}
