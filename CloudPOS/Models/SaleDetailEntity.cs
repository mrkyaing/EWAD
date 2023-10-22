using System.ComponentModel.DataAnnotations.Schema;

namespace CloudPOS.Models
{
    [Table("SaleDetail")]
    public class SaleDetailEntity:BaseEntity
    {
        [ForeignKey("SaleId")]
        public string SaleId { get; set; }
        public virtual SaleEntity Sale { get; set; }
        [ForeignKey("ItemId")]
        public string ItemId { get; set; }
        public virtual ItemEntity Item { get; set; }
        public int Qty { get; set; }
        public string Remark { get; set; }
    }
}
