using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal interface ITeacherObserver
    {
        void Update(string message);
    }


    internal class Teacher : ITeacherObserver
    {
        public string Name { get; set; }

        public Teacher(string name)
        {
            Name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"Notification for {Name}: {message}");
        }
    }
}
