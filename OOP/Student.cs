using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP {
    public class Student {
        //private variable
        private string name;
        private string address;
        private int age;
        private string email;
        public string Email
        {
            get { return email; }
            set {
                if (!value.Contains("@")) throw new ArgumentException("invalid email");
                email = value; 
            }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set {
                if (!value.Contains("09") || value.Length > 11 | value.Length < 11) throw new ArgumentException("invalid MM Phone Number");
                phone = value; }
        }

        //Property of name variable
        public string Name
        {
            get { return name; } 
            set {  
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("invalid name");
            name = value;
            }
        }
        //Property of address variable
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        //Property of age variable
        public int Age
        {
            get { return age; }
            set { 
                if(value < 0) throw new ArgumentException("invalid age");
                age=value;
            }
        }
    }
}
