namespace CloudPOS.Models.ViewModels
{
    public class SaleDetailViewModel
    {
        public string Id { get; set; }
        public string  ItemInfo { get; set; }
        public string SaleId { get; set; }
        public string ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Qty { get; set; }
        public string Remark { get; set; }
    }
}
