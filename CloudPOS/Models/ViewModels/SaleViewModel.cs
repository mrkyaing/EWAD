namespace CloudPOS.Models.ViewModels
{
    public class SaleViewModel
    {
        public string Id { get; set; }
        public string VoucherNo { get; set; }
        public DateTime SaledDate { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
