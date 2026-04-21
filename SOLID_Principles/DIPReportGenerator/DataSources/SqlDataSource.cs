using System;
using System.Collections.Generic;
using DIPReportGenerator.Core;

namespace DIPReportGenerator.DataSources
{
    /// <summary>
    /// مصدر بيانات يمثل جلب البيانات من قاعدة بيانات SQL.
    /// يطبق واجهة IDataSource.
    /// </summary>
    public class SqlDataSource : IDataSource
    {
        private readonly string _connectionString;

        public SqlDataSource(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// جلب البيانات من قاعدة بيانات SQL (محاكاة).
        /// </summary>
        /// <returns>قائمة من القواميس تمثل البيانات.</returns>
        public List<Dictionary<string, string>> GetData()
        {
            Console.WriteLine($"SqlDataSource: Connecting to SQL database with connection string: {_connectionString}");
            // محاكاة جلب البيانات من قاعدة بيانات SQL
            return new List<Dictionary<string, string>>
            {
                new Dictionary<string, string> { { "ID", "1" }, { "Name", "Product A" }, { "Price", "100" } },
                new Dictionary<string, string> { { "ID", "2" }, { "Name", "Product B" }, { "Price", "150" } }
            };
        }
    }
}
