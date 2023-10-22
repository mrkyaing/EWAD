using System.ComponentModel.DataAnnotations.Schema;

namespace CloudPOS.Models
{
    [Table("Sale")]
    public class SaleEntity:BaseEntity
    {
        public string VoucherNo { get; set; }
        public DateTime SaledDate { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
