using CloudPOS.Models.ViewModels;
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
        public IList<ItemViewModel> GetItemReportBy(string itemCode, string brandId, string categoryId)
        {
            IList<ItemViewModel > items = new List<ItemViewModel>();
            if(!string.IsNullOrEmpty(itemCode))
                items= _itemService.GetAll().Where(x => x.ItemCode == itemCode).ToList();
            else if (brandId!="a")
                items = _itemService.GetAll().Where(x => x.BrandId == brandId).ToList();
            else if (categoryId!="a")
                items = _itemService.GetAll().Where(x =>  x.CategoryId == categoryId).ToList();
            else
                items = _itemService.GetAll().ToList();
            return items;
        }
    }
}
