using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        
        public List<Course> EnrolledCourses { get; set; } = new List<Course>();
        public List<Instructor> AssignedInstructors { get; set; } = new List<Instructor>();
    }
}
