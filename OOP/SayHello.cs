namespace OOP {
    public abstract class SayHello {
        public string Name { get; set; }
        public string Address { get; set; }
        
        //abstract method 
        public abstract void SayGreetingMessage();
        //abstract method
        public abstract void AboutMe();

        //non-abstract method
        public void DispalyInfo() {
            Console.WriteLine($"Hi,i am {Name}. i live in {Address}");
        }
    }
}
