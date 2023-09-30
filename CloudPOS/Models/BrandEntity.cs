using System.ComponentModel.DataAnnotations.Schema;

namespace CloudPOS.Models
{
    [Table("Brand")]
    public class BrandEntity:BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? ManufacturedCompany { get; set; }
        public virtual ICollection<ItemEntity>? Items { get; set; }
    }
}
