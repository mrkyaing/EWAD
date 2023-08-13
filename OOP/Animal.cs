namespace OOP {
    public class Animal {
		private int id;
		public int Id
		{
			get { return id; }
			set { id = value; }
		}
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
        public string Color { get; set; }
		public virtual void Eat() {
			Console.WriteLine($"{Name} is eating.");
		}
		public virtual void Sleep() {
            Console.WriteLine($"{Name} is sleeping.");
        }
		public virtual void Speak() {
            Console.WriteLine($"{Name} is speaking.");
        }
		public virtual void Walk() {
            Console.WriteLine($"{Name} is walking. ");
        }
    }
}
