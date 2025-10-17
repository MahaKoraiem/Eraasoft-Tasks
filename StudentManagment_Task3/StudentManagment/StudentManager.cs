using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment
{
    internal class StudentManager
    {
        public static bool AddStudent(string name, int age)
        {
            int id = Database.Students.Count + 1;
            Student student = new Student()
            {
                Name = name,
                Age = age,
                Id = id
            };

            if(student != null)
            {
                Database.Students.Add(student);
                return true;
            }

            return false;
        }

        public static bool RemoveStudent(int id)
        {
            var student = Database.Students.Find(s=> s.Id == id);
            if(student != null)
            {
                Database.Students.Remove(student);
                return true;
            }
            return false;
        }

        public static Student FindStudentById(int id)
        {
            var student = Database.Students.Find(s => s.Id == id);
            if(student != null)
            {
                return student;
            }
            return null;
        }

        public static Student FindStudentByName(string name)
        {
            var student = Database.Students.Find(s => s.Name == name);

            if(student != null)
            {
                return student;
            }

            return null;
        }

        public static List<Student> GetAllStudents()
        {
            var result = Database.Students.Select(s=>s);
            return result.ToList();
        }

        public static List<Course> GetEnrolledCourses(string studentName)
        {
            var student = FindStudentByName(studentName);
            if(student != null)
            {
                return student.EnrolledCourses;
            }
            return null;
        }

        public static bool IsStudentEnrolledInCourse(string studentName, string courseName)
        {
            var student = FindStudentByName(studentName);
            var course = CourseManager.FindCourseByName(courseName);

            bool result = false;
            if (student != null && course != null)
            {
                result = student.EnrolledCourses.Contains(course);
            }
            return result;
        }

        public static List<Instructor> GetAssignedInstructors(string studentName)
        {
            var student = FindStudentByName(studentName);
            if(student != null)
            {
                return student.AssignedInstructors;
            }
            return null;
        }
    }
}
