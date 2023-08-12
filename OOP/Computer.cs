using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP {
    public class Computer {
        //state of computer  // Have 
        public  string CPU, RAM,Storage, Model;
        public  decimal UnitPrice;
        public DateTime ManufacturedDate;
       
        public Computer() { // default-Constructor
            CPU = "Nothing";
            RAM = "Nothing";
            Storage = "Nothing";
            Model = "Nothing";
        }
        public Computer(string cpu, string ram, string storage, string model,decimal unitPrice) {//paramarized constructor 
            CPU= cpu;
            RAM= ram;
            Storage= storage;
            Model = model;
            UnitPrice= unitPrice;
        }
        public Computer(string cpu, string ram, string storage, string model, decimal unitPrice,DateTime manufacturedDate) {//paramarized constructor 
            CPU = cpu;
            RAM = ram;
            Storage = storage;
            Model = model;
            UnitPrice = unitPrice;
            ManufacturedDate = manufacturedDate;
        }
        //behaviors / Do
        public void PowerOn() {
            Console.WriteLine("PC is Power on.");
        }
        //method overloading  PowerOff() methods
        public void PowerOff() { 
            Console.WriteLine("PC is Power Off."); 
        }
        public void PowerOff(int shutdownSecond) {
            Console.WriteLine($"PC will power off within {shutdownSecond}.");
        }
        public void PlayMusic(string songName) {
            Console.WriteLine($"{songName} is playing now.");
        }
        public  void Specification() {
            Console.WriteLine("Model : " + Model);
            Console.WriteLine("CPU :" + CPU);
            Console.WriteLine("RAM :" + RAM);
            Console.WriteLine("Storage : " + Storage);
            Console.WriteLine("Manufactured At : " + ManufacturedDate);
            Console.WriteLine("Unit Price :" + UnitPrice +"$");
        }

       public static void ConnectToPrinter() {
            Console.WriteLine("Connection to a printer");
        }
    }
}
