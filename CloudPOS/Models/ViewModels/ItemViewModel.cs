namespace CloudPOS.Models.ViewModels
{
    public class ItemViewModel
    {
        public string Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public string CategoryId { get; set; }
        public string BrandId { get; set; }
    }
}
