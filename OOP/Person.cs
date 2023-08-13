namespace OOP {
    public class Person {
       
        private int Id;
        public string Name;
        private DateTime DOB;
        public string Address;
        private string Email;

        public static void SayHello(string what) {
            Console.WriteLine($"{what}");
        }
        public void AboutMe() {
            Console.WriteLine($"Hi,i am {Name}.I live in {Address} .i am {DateTime.Now.Year-DOB.Year} years old. my id {Id}. you can send me some message this email :{Email}.");
        }

        public string GetEmail() {
            return Email;
        }
        public void SetEmail(string email) {
            if(!email.Contains("@")) {
                throw new ArgumentException("invalid email address");
            }
            Email = email;
        }
        public int Getid() => Id;
        public void SetId(int id) {//1
            if (id < 0) {
                throw new ArgumentException("invalid Id");
            }
            Id = id;//1
        }
        public DateTime GetDOB() => DOB;
        public void SetDOB(DateTime dOB) {
            if (DOB > DateTime.Now) {
                throw new ArgumentException("invalid DOB");
            }
            DOB = dOB;
        }
    }
}
