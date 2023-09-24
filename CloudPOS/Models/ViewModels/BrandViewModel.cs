namespace CloudPOS.Models.ViewModels
{
    public class BrandViewModel
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string? ManufacturedCompany { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
