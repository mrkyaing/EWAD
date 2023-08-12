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
	p2.SetId(-503);
	p2.Name = "su su";
	p2.SetEmail("susu");
	p2.SetDOB(Convert.ToDateTime("2026-07-11"));
	p2.AboutMe();
}
catch (Exception e) {
	Console.WriteLine("Error" + e.Message);
}