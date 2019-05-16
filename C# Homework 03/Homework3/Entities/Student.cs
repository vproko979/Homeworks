using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3.Entities
{
    public class Student
    {
        public string Name { get; set; }
        public string Academy { get; set; }
        public string Group { get; set; }

        public Student(string name, string academy, string group)
        {
            this.Name = name;
            this.Academy = academy;
            this.Group = group;
        }

        public string ShowStudentsInfo()
        {
            return $"Name: {Name},\n" +
                   $"Academy: {Academy},\n" +
                   $"Group: {Group}";
        }
    }
}
