using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePracticeWithMVC.Models
{
    [Table("Student")]
    public class StudentEntity:BaseEntity
    {
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }

    }
}
