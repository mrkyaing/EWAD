namespace OOP {
    public class Dog:Animal {
        public void MakeSecurity() {
            Console.WriteLine($"{Name} watching thieves");
        }

        public override void Eat() {
           Console.WriteLine($"{Name} is eating meal.");
        }

        public override void Speak() {
            Console.WriteLine("Woak.Woak.Woak");
        }

        public override void Walk() {
         Console.WriteLine("walking as a lion.");
        }

    }
}
