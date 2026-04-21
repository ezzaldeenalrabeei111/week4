using System.Collections.Generic;

namespace DIPReportGenerator.Core
{
    /// <summary>
    /// واجهة لمصادر البيانات. تمثل التجريد الذي يعتمد عليه ReportGenerator.
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// جلب البيانات من المصدر.
        /// </summary>
        /// <returns>قائمة من القواميس تمثل البيانات.</returns>
        List<Dictionary<string, string>> GetData();
    }
}
