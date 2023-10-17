using System.ComponentModel.DataAnnotations.Schema;

namespace CloudPOS.Models
{
    [Table("StockInCome")]
    public class StockInComeEntity:BaseEntity
    {
        public DateTime IncomedDate { get; set; }
        public string ItemId { get; set; }
        public decimal Qty { get; set; }
    }
}
