using System.ComponentModel.DataAnnotations.Schema;

namespace CloudPOS.Models
{
    [Table("Item")]
    public class ItemEntity:BaseEntity
    {
        public string ItemCode { get; set; }
        public string ItemDescription { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }

        [ForeignKey("CategoryId")]
        public string CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; }//Navigation Property to check category information
        [ForeignKey("BrandId")]
        public string BrandId { get; set; }
        public virtual BrandEntity Brand { get; set; }//Navigation Property to check brand information
    }
}
