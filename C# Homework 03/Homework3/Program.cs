using System;
using Homework3.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[5];

            students[0] = new Student("John", "Web Programing", "G2");
            students[1] = new Student("Leanne", "Web Programing", "G1");
            students[2] = new Student("Bob", "Web Programing", "G3");
            students[3] = new Student("Chelsey", "Web Design", "G4");
            students[4] = new Student("Dennis", "CCNA", "G6");

            Console.Write(@"Search for a student: ");
            string usersInput = Console.ReadLine().ToLower();
            string result = "";
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Name.ToLower() == usersInput)
                {
                    result = students[i].ShowStudentsInfo();
                }
            }

            if (result.Length == 0)
            {
                Console.WriteLine("There's no student by that name.");
            }
            else
            {
                Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}
