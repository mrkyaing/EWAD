using CloudPOS.Reports.DataSets;
using CloudPOS.Services;

namespace CloudPOS.Reports.Common
{
    public class Reporting : IReporting
    {
        private readonly IItemService _itemService;
        public Reporting(IItemService itemService)
        {
            _itemService = itemService;
        }
        public IList<ItemDetailReportDataSet> GetItemReportBy(string itemCode, string brandId, string categoryId)
        {
            var items = new List<ItemDetailReportDataSet>();
            if (!string.IsNullOrEmpty(itemCode))
                items = _itemService.GetAll().Where(x => x.ItemCode == itemCode).Select(s => new ItemDetailReportDataSet
                {
                    ItemCode = s.ItemCode,
                    ItemDescription = s.ItemDescription,
                    BrandInfo = s.BrandInfo,
                    CategoryInfo = s.CategoryInfo,
                    PurchasePrice = s.PurchasePrice,
                    SalePrice = s.SalePrice,
                    ExportedAt = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                }).ToList();

            else if (brandId != "a")
                items = _itemService.GetAll().Where(x => x.BrandId == brandId).Select(s => new ItemDetailReportDataSet
                {
                    ItemCode = s.ItemCode,
                    ItemDescription = s.ItemDescription,
                    BrandInfo = s.BrandInfo,
                    CategoryInfo = s.CategoryInfo,
                    PurchasePrice = s.PurchasePrice,
                    SalePrice = s.SalePrice,
                    ExportedAt = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                }).ToList();
            else if (categoryId != "a")
                items = _itemService.GetAll().Where(x => x.CategoryId == categoryId).Select(s => new ItemDetailReportDataSet
                {
                    ItemCode = s.ItemCode,
                    ItemDescription = s.ItemDescription,
                    BrandInfo = s.BrandInfo,
                    CategoryInfo = s.CategoryInfo,
                    PurchasePrice = s.PurchasePrice,
                    SalePrice = s.SalePrice,
                    ExportedAt = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                }).ToList();
            else
                items = _itemService.GetAll().Select(s => new ItemDetailReportDataSet
                {
                    ItemCode = s.ItemCode,
                    ItemDescription = s.ItemDescription,
                    BrandInfo = s.BrandInfo,
                    CategoryInfo = s.CategoryInfo,
                    PurchasePrice = s.PurchasePrice,
                    SalePrice = s.SalePrice,
                    ExportedAt = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")
                }).ToList();
            return items;
        }
    }
}
