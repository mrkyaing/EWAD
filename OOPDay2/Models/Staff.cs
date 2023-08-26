using OOPDay2.Impl;
using OOPDay2.Interfaces;

namespace OOPDay2.Models {
    public class Staff:IShowDetail {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal BasicSalary { get; set; }
        public DateTime JoinedDate { get; set; }
        public BankAccount   BankAccount { get; set; }// Has-Relatinship

        //enforcing the implementation that you inherited Of Base Class .
        public void DisplayInfo() {
            Console.WriteLine("Staff Information");
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Id}");
            Console.WriteLine($"Email: {Id}");
            Console.WriteLine($"Address: {Id}");
            Console.WriteLine($"Basic Salary: {Id}");
        }
    }
}
