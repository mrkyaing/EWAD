using System;
namespace ConsoleApp {
    public class Test {
        public int Add() {
            int result = 1 + 1;
            return result;
        }

        public int CheckAge(int age) {
            if (age < 0)
                throw new ArgumentException("invalid age");
            return age;
        }

        public HashSet<int> GetAge()
        {
            HashSet<int> result = new HashSet<int>();
            result.Add(1);
            result.Add(2);
            result.Add(3);
            result.Add(3);
            result.Add(4);
            return result;
        }
    }
}

namespace StudentInfo {
   public class Student {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

namespace TeacherInfo {
   public class Teacher {
        public string Name { get; set; }
       
        public void GetTotalMark() {
            int total = 0;
            int[] marks=new int[30]; // 0 to 29 
            marks[0] = 10;
            marks[1] = 30;
            marks[2] = 30;
           // marks[30] = 300; //Index out of bound exception
            for(int i=0;i<marks.Length;i++) { 
                total += marks[i]; // 70
            }
            Console.WriteLine(total);
        }
    }
}


namespace SchoolInfo {
  public class Teacher {
        public string Name { get; set; }
    }
}
