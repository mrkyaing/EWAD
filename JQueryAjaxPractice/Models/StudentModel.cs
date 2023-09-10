namespace JQueryAjaxPractice.Models
{
    public class StudentModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public Address HomeAddress { get; set; }//Has-a Relationship mean Compsition with Address
    }

    public class Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Township { get; set; }
        public string? PostalCode { get; set; }
        public string? Street { get; set; }
    }
}
