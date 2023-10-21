namespace CloudPOS.Models.ViewModels
{
    public class StockInComeViewModel
    {
        public string Id { get; set; }
        public DateTime IncomedDate { get; set; }
        public string ItemId { get; set; }
        public string ItemInfo { get; set; }
        public decimal Qty { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
