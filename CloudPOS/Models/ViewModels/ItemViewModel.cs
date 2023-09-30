namespace CloudPOS.Models.ViewModels
{
    public class ItemViewModel
    {
        public string Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public string CategoryId { get; set; }// create , update  
        public string BrandId { get; set; }// create , update  
        public string? BrandInfo { get; set; } // to show the user for brand info 
        public string? CategoryInfo { get; set; } // to the user for category info
        public DateTime CreatedAt { get; set; }
    }
}
