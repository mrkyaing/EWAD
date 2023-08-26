using OOPDay2.Impl;
using OOPDay2.Interfaces;
using OOPDay2.Models;

Console.WriteLine("Abstraction Practice with Payroll System");

Staff s1 = new Staff(){
    Id = "s001",
    Name = "Smith",
    JoinedDate = new DateTime(2022,08,19),
    BasicSalary=300000,
    Address="YGN"
};
BankAccount ba1 = new BankAccount(){
    AccountNumber = "111111",
    OpeningBalance = 1000
};
s1.BankAccount = ba1;

Staff s2 = new Staff(){
    Id = "s002",
    Name = "Jame",
    JoinedDate = new DateTime(2021, 08, 19),
    BasicSalary = 400000,
    Address = "MDY",
    BankAccount = new BankAccount(){
        OpeningBalance= 3000,
       AccountNumber="222222"
    }
};



List<Staff> employess = new List<Staff>();
employess.Add(s1);
employess.Add(s2);

IPayrollService payroll = new PayrollService();

foreach(var s in employess) {
    decimal netpay = payroll.CalculatePayroll(s, 30, 30);//300000
    Console.WriteLine($"Employee {s.Name} get the net pay salary {netpay}");
    decimal bonus = payroll.CalculateBonus(s.BasicSalary, s.JoinedDate);
    if (bonus > 0) 
        Console.WriteLine($"Hay, {s.Name} Conguration you will get the service years bonus {bonus}");
    Console.WriteLine($"Final Net Pay of {s.Name} is " + (netpay + bonus));
}

ICreditCard creditCard = new BankAccount();
decimal usd=creditCard.GetUSDollorExchangeRate(750);
Console.WriteLine($"USD Exchange Rate:{usd}");

