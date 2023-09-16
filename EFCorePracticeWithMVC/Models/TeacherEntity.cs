using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCorePracticeWithMVC.Models
{
    [Table("Teacher")]
    public class TeacherEntity:BaseEntity
    {
        public string FirstName { get; set; }

    }
}
