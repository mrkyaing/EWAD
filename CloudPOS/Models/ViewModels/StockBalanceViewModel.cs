namespace CloudPOS.Models.ViewModels
{
    public class StockBalanceViewModel
    {
        public string ItemInfo { get; set; }
        public decimal Quantity { get; set; }
        public decimal MininumQuantity { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
