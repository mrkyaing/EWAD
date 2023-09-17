using CloudPOS.Utlis;
using System.ComponentModel.DataAnnotations;

namespace CloudPOS.Models
{
    public class BaseEntity
    {
        //Primary Key Column for related child Entity
        [Key]
        public string Id { get; set; }
        //Audit Columns
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; }
        public string IP { get; set; } = NetworkHelper.GetLocalIPAddress();
    }
}
