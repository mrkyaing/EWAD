using System.ComponentModel.DataAnnotations.Schema;

namespace CloudPOS.Models
{
    [Table("Category")]
    public class CategoryEntity:BaseEntity
    {
        public  string Code { get; set; }
        public string? Description { get; set; }
    }
}
