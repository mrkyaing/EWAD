namespace OOP {
    public class Cat:Animal{
     public void CatchMices() {
            Console.WriteLine("Catching Mices");
        }
        public override void Eat() {
            Console.WriteLine($"{Name} is eating mice.");
        }

        public override void Speak() {
            Console.WriteLine("Meow.Meow.Meow");
        }

        public override void Walk() {
            Console.WriteLine("walking as a LION.");
        }
    }
}
