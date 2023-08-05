using System.ComponentModel;

Console.WriteLine("Hello, World!");
Console.WriteLine("Hi");
int i = 10;
if(i%2 == 0) {
    Console.WriteLine("i is even number");
}
else {
    Console.WriteLine("i is odd number");
}
byte b = 10;
Console.WriteLine("Byte value is " + b);//string concentation syntax style
Console.WriteLine($"Byte value is {b}");//string interpolation syntax style
short s = 20;
Console.WriteLine($"short value is {s}");
long l = 10000;
Console.WriteLine($"long value is {l}");
float f = 20.3f;
double d = 30.3;
decimal dd = 9.0m;
var k = 100;
Console.WriteLine($"k value is {k}");
char letter='A';
Console.WriteLine($"Letter value is {letter}");
string msg = "Hello";
Console.WriteLine($"Message is {msg}");
var now=DateTime.Now;
Console.WriteLine($"Current Date Time is {now}");
string day = "SAT";
switch (day) {
    case "SAT":Console.WriteLine("HAPPY Weekend");break;
    case "SUN": Console.WriteLine("HAPPY Weekend"); break;
    case "MON": Console.WriteLine("DUTY Week"); break;
    default: Console.WriteLine("Invalid Day");break;
}

string[] fruits = { "apple","bananna","pineapple","stawabary"};
for(int j = 0; j < fruits.Length; j++) {
    Console.WriteLine(fruits[j]);//  apple  ,bananna
}

foreach(string z in fruits) {
    Console.WriteLine(z);//  apple  ,bananna
}
int result = 1 + 2 /1 * 3;// Multiplicative Operator * % / , addative operators + - 
Console.WriteLine($"result is {result}");//7
int result2 = 3 + 3 / 3 * 2 - 1 + 1;//3+2-1-1 >> 5
Console.WriteLine($"result is {result2}");//7