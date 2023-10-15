using CloudPOS.Reports.DataSets;

namespace CloudPOS.Reports.Common
{
    public interface IReporting
    {
        /// <summary>
        /// Get Item report according to item code,branId and categoryId
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="brandId"></param>
        /// <param name="categoryId"></param>
        /// <returns>Lit of ItemDetailReportDataSet</returns>
        IList<ItemDetailReportDataSet> GetItemReportBy(string itemCode, string brandId, string categoryId);
    }
}
