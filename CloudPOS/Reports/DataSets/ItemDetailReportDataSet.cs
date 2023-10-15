namespace CloudPOS.Reports.DataSets
{
    public class ItemDetailReportDataSet
    {
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public string? BrandInfo { get; set; } // to show the user for brand info 
        public string? CategoryInfo { get; set; } // to the user for category info
        public string ExportedAt { get; set; }
    }
}
