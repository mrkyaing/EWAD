using OOP;

Console.WriteLine("OOP Practices");

Computer dell=new Computer(); // create a instance of Computer class  or create a object 
dell.CPU = "i7 13th Generation";
dell.RAM = "8GB";
dell.Storage = "500GB";
dell.UnitPrice =179.55m;
dell.Model = "Inspration";
dell.ManufacturedDate = Convert.ToDateTime("2022-09-10");
dell.PowerOn();
dell.PlayMusic("something");
dell.Specification();
dell.PowerOff();
Computer.ConnectToPrinter();

Computer hp = new Computer(); // create a instance of Computer class  or create a object 
hp.CPU = "i5 13th Generation"; // passing the data to the instance variables/states
hp.RAM = "4GB";
hp.Storage = "1TB";
hp.UnitPrice = 580.90m;
hp.Model = "ProBook";
hp.ManufacturedDate = Convert.ToDateTime("2021-09-10");
hp.PowerOn();// calling the method called to the instance of class / object 
hp.Specification();
hp.PowerOff();
Computer.ConnectToPrinter();
Computer acer=new Computer("i3","4GB","256GB","TravelBook",385m);//passing the data with parameterized constructor
acer.ManufacturedDate = Convert.ToDateTime("2023-01-01");//passing the data with . Operator
acer.Specification();
Computer.ConnectToPrinter();

Helper.Utilitity.Now();
Helper.SayHi.SayHello();

Console.WriteLine("============Encapsulation Demo============");

try {
	Person p1 = new Person();
	p1.SetId(1);
	p1.Name = "Mg Mg";
	p1.Address = "YGN";
	p1.SetEmail("mgmg@gmail.com");
	p1.SetDOB(Convert.ToDateTime("1998-10-10"));
	Person.SayHello("Hello,Nice to see you");
	p1.AboutMe();

	Person p2 = new Person();
	p2.SetId(503);//pass the data with Setter
	p2.Name = "su su";
	p2.SetEmail("susu");
	p2.SetDOB(Convert.ToDateTime("2022-07-11"));
	p2.AboutMe();
	Console.WriteLine($"email of person 2 {p2.GetEmail()}"); // get the data with Getter 

    Person p3 = new Person();
    p3.SetId(2);
    p3.Name = "Saw";
    p3.Address = "YGN";
    p3.SetEmail("saw@gmail.com");
    p3.SetDOB(Convert.ToDateTime("1998-10-10"));
    Person.SayHello("Hello,Nice to see you");
    p3.AboutMe();
}
catch (Exception e) {
	Console.WriteLine("Error" + e.Message);
}

Student s1=new Student();
s1.Name = "susu";
s1.Address = "YGN";
s1.Age = 20;
s1.Email = "susu@gmil.com";
s1.Phone = "09256275319";

Console.WriteLine("Name" + s1.Name);

Cat c = new Cat();
c.Name = "jacky puccy";
c.Color = "Yellow";
c.Id = 1;
c.Eat();
c.CatchMices();
c.Sleep();
c.Walk();
c.Speak();
c.Sleep();

Dog d = new Dog();
d.Name = "Jame Dokker";
d.Color = "Black";
d.Eat();
d.MakeSecurity();
d.Sleep();
d.Walk();
d.Speak();
d.Sleep();

Dog d2 = new Dog(){
	Name = "smith",
	Color = "Black",
	Id = 3
};
d2.MakeSecurity();
d2.Sleep();
d2.Speak();

MyanmarPeople myanmar = new MyanmarPeople()
{
	Name = "Mg Mg",
	Address="YGN"
};
JapanesePeople japanese = new JapanesePeople()
{
	Name = "Khoniee",
	Address = "Toko"
};
EnglishPeople english = new EnglishPeople()
{
	Name = "David Jone",
	Address = "USA"
};

myanmar.SayGreetingMessage();
myanmar.DispalyInfo();
myanmar.AboutMe();
english.SayGreetingMessage();
english.DispalyInfo();
english.AboutMe();
japanese.SayGreetingMessage();
japanese.DispalyInfo();
japanese.AboutMe();