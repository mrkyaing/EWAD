using CloudPOS.Models.ViewModels;

namespace CloudPOS.Reports.Common
{
    public interface IReporting
    {
        IList<ItemViewModel> GetItemReportBy(string itemCode, string brandId, string categoryId);
    }
}
