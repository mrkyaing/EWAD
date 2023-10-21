using System.ComponentModel.DataAnnotations.Schema;

namespace CloudPOS.Models
{
    [Table("StockBalance")]
    public class StockBalanceEntity:BaseEntity
    {
        [ForeignKey("ItemId")]
        public string ItemId { get; set; }
        public virtual ItemEntity Item { get; set; }
        public decimal Qty { get; set; }
        public decimal MininumQty { get; set; } = 3;
    }
}
