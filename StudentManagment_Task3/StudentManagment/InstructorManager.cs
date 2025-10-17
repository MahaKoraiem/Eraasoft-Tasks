using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentManagment
{
    internal class InstructorManager
    {
        public static bool AddInstructor(string name, string specialization)
        {
            int id = Database.Instructors.Count + 1;
            Instructor instructor = new()
            {
                Id = id,
                Name = name,
                Specialization = specialization
            };

            if(instructor != null)
            {
                Database.Instructors.Add(instructor);
                return true;
            }

            return false;
        }

        public static bool RemoveInstructor(int id)
        {
            var result = Database.Instructors.Find(s=> s.Id == id);
            if(result != null)
            {
                Database.Instructors.Remove(result);
                return true;
            }
            return false;
        }

        public static Instructor FindInstructorById(int id)
        {
            var result = Database.Instructors.Find(s=>s.Id == id);
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public static Instructor FindInstructorByName(string name)
        {
            var result = Database.Instructors.Find(s=>s.Name == name);
            if(result != null)
            {
                return result;
            }
            return null;
        }

        public static Instructor FindInstructorByCourse(string courseName)
        {
            var course = CourseManager.FindCourseByName(courseName);
            if(course != null)
            {
                var instructorId = course.InstructorId;
                var instructor = FindInstructorById(instructorId);
                
                return instructor;
               
            }
            return null;
        }

        public static Instructor FindBySpecialization(string specialization)
        {
            var result = Database.Instructors.Find(s=>s.Specialization == specialization);
            if(result != null)
            {
                return result;
            }
            return null;
        }

       
        public static List<Instructor> GetAllInstructors()
        {
            var result = Database.Instructors.Select(s=>s);
            if(result != null)
            {
                return result.ToList();
            }
            return null;
        }
    }
}
