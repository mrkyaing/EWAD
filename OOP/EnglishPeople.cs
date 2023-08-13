using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP {
    public class EnglishPeople : SayHello {
        public override void AboutMe() {
            Console.WriteLine("I am fine");
        }

        public override void SayGreetingMessage() {
            Console.WriteLine("Hello,nice to see you");
        }
    }
}
