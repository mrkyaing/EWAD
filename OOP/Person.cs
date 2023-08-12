namespace OOP {
    public class Person {
       
        private int Id;
        private string Name;
        private DateTime DOB;
        public string Address;
        private string Email;

        public static void SayHello(string what) {
            Console.WriteLine($"{what}");
        }
        public void AboutMe() {
            Console.WriteLine($"Hi,i am {Name}.I live in {Address} .i am {DateTime.Now.Year-DOB.Year} years old. my id {Id}. you can send me some message this email :{Email}.");
        }

        public void SetEmail(string email) {
            if(!email.Contains("@")) {
                throw new ArgumentNullException("invalid email address");
            }
            Email = email;
        }

        public void SetId(int id) {
            if (id < 0) {
                throw new ArgumentNullException("invalid Id");
            }
            Id = id;
        }

        public void SetDOB(DateTime dOB) {
            if (DOB > DateTime.Now) {
                throw new ArgumentNullException("invalid DOB");
            }
            DOB = dOB;
        }
    }
}
