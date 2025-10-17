using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment
{
    internal class CourseManager
    {
        public static bool AddCourse(string courseName, int instructorId)
        {
            int id = Database.Courses.Count + 1;
            Course course = new()
            {
                Id = id,
                Name = courseName,
                InstructorId = instructorId
            };

            if(course != null)
            {
                Database.Courses.Add(course);
                return true;
            }
            return false;
        }

        public static bool RemoveCourse(int id)
        {
            var result = Database.Courses.Find(s => s.Id == id);
            if(result != null)
            {
                Database.Courses.Remove(result);
                return true;
            }
            return false;
        }

        public static bool EnrollStudentInCourse(string studentName, string courseName)
        {
            var student = StudentManager.FindStudentByName(studentName);
            var course = Database.Courses.Find(c => c.Name == courseName);

            if(student != null && course != null)
            {
                var result = student.EnrolledCourses.Find(e => e.Name == courseName);

                if(result == null)
                {
                    student.EnrolledCourses.Add(course);
                    return true;
                }
            }
            return false;
        }

        //public static bool AssignCourseToInstructor(string instructorName, string courseName)
        //{
        //    var instructor =InstructorManager.FindInstructorByName(instructorName);
        //    var course = FindCourseByName(courseName);
        //    if (instructor != null && course != null)
        //    {
        //        instructor.AssignedCourses.Add(course);
        //        return true;
        //    }
        //    return false;
        //}
        public static Course FindCourseByName(string name)
        {
            var result = Database.Courses.Find(c => c.Name == name);
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public static Course FindCourseById(int id)
        {
            var result = Database.Courses.Find(c=> c.Id == id);
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public static List<Course> GetAllCourses()
        {
            var result = Database.Courses.Select(c => c);
            if(result != null)
            {
                return result.ToList();
            }
            return null;
        }


    }
}
