using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp {
    public class CollectionPractice {

        public void SettingNumbers() {
            
            IList<int> numbers = new List<int>(); // Generic Collection
            numbers.Add(1);
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
            numbers.Add(5);
            numbers.Add(30);
             foreach(var i in  numbers) {
                Console.WriteLine(i);
            }

            List<string> messages = new List<string>(); // Generic Collection
            messages.Add("Hi");
            messages.Add("Hello");
            messages.Add("How are you");
            //messages.Add(10);// error because it is generic type collection
            foreach(var ii in messages) 
                { Console.WriteLine(ii); }

            ArrayList a = new ArrayList();//Non-Generic 
            a.Add("hello");
            a.Add(10);
            a.Add(true);
            a.Add(false);
            a.Add(20.3);
            foreach(var i in a) {
                Console.WriteLine(i);
            }
           
            Stack s = new Stack();//Non-Generic >> LIFO principle
            s.Push("hello");
            s.Push(10);
            Console.WriteLine(s.Pop());// 10
            Console.WriteLine(s.Pop());// Hello
            Stack<string> sms = new Stack<string>();//Generic 
            sms.Push("Okay");
            sms.Push("Fine");
            //sms.Push(10);// error becaue it is generic collection type

            Queue q = new Queue();//Non Generic Type  >> FIFO principle 
            q.Enqueue("hello");
            q.Enqueue(10);
            q.Enqueue(true);
            q.Enqueue(false);
            q.Enqueue(30.6);
           Console.WriteLine(q.Dequeue()); // Hello

          Queue<string> ticket=new Queue<string>();
          ticket.Enqueue("F001");
          ticket.Enqueue("z001");
          //ticket.Enqueue(10);
          Console.WriteLine(ticket.Dequeue());//F001 z001

            IDictionary<int,string> myDctionary=new Dictionary<int,string>(); // Generic type
            myDctionary.Add(1, "Apple");
            myDctionary.Add(3, "Samsaung");
            //myDctionary.Add(1, "LG"); Error because key 1 is already existed in dictonary 
            foreach(KeyValuePair<int,string> kvp in myDctionary) {
                Console.WriteLine(kvp.Value);
            }
            Console.WriteLine(myDctionary[1]);

            Hashtable hashtable = new Hashtable(); // non Generic Type
            hashtable.Add(1, "Okay");
            hashtable.Add(3, "Hi");
            Console.WriteLine("my value is " + hashtable[3]);//Hi
            Console.WriteLine(hashtable[10]);//
            foreach(DictionaryEntry i in hashtable) {
                Console.WriteLine(i.Value);
            }
        }
    }
}
