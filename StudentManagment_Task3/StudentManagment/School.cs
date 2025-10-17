using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagment
{
    internal class School
    {
        public static void Start()
        {
            Console.WriteLine("Welcome to the School Management System");
            Console.WriteLine("------------------------------------------");
            if (Database.Instructors.Count == 0 && Database.Courses.Count == 0)
            {
                Console.WriteLine("** Warning:Tables are empty!! **");
                Console.WriteLine("------------------------------------------");
            }

            Console.WriteLine("creating Instructors Table");
            Console.WriteLine("------------------------------------------");

            CreateInstructorsTable();
            Console.WriteLine();

            PrintInstructorsTable();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Creating Courses Table");
            Console.WriteLine("------------------------------------------");

            CreateCoursesTable();

            Console.WriteLine();
            PrintCoursessTable();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Creating Students Table");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine();

            CreateStudentsTable();
            Console.WriteLine();

            PrintStudentsTable();
            Console.WriteLine();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("All tables created successfully.");
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("What do you want to do ?");

            Console.WriteLine("1. Enroll a student in a course");
            Console.WriteLine("2. Get all Enrolled courses for a student");
            Console.WriteLine("3. check the enrollment of a student");
            Console.WriteLine("4. Search for student by ID");
            Console.WriteLine("5. Search for student by name");
            Console.WriteLine("6. Add new student");
            Console.WriteLine("7. Remove student");
            Console.WriteLine("8. show all students");

            Console.WriteLine();
            Console.WriteLine("10. Search for instructor by name");
            Console.WriteLine("11. Search for instructor by ID");
            Console.WriteLine("12. Search for instructor by Course");
            Console.WriteLine("13. Search for instructor by specialization");
            Console.WriteLine("14. Add new instructor");
            Console.WriteLine("15. Remove instructor");
            Console.WriteLine("16. show all instructors");
            Console.WriteLine();

            Console.WriteLine("17. Search for a course by name");
            Console.WriteLine("18. Search for a course by ID");
            Console.WriteLine("19. Add new course");
            Console.WriteLine("20. Remove course");
            Console.WriteLine("21. show all courses");
            Console.WriteLine("22. Exit");
                int choice = 0;
            do
            {
                choice = Convert.ToInt32(Console.ReadLine());
                if(choice >=1 && choice <= 8)
                {
                    ChoicesForStudent(choice);

                }else if(choice >=9 && choice <=16)
                {
                    ChoicesForInstructor(choice);
                }
                else if(choice >=17 && choice <=22)
                {
                    ChoicesForCourse(choice);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

            }while (choice != 22);

        }
        public static void CreateInstructorsTable()
        {
            string name, specialization, userChoice;

            do
            {
                Console.WriteLine("Enter the name :");
                name = Console.ReadLine();
                Console.WriteLine("Enter the specialization :");
                specialization = Console.ReadLine();
                if (InstructorManager.AddInstructor(name, specialization))
                {
                    Console.WriteLine("------------------------------------------");

                    Console.WriteLine("Instructor added successfully.");
                    Console.WriteLine("------------------------------------------");

                }
                else
                {
                    Console.WriteLine("------------------------------------------");

                    Console.WriteLine("Failed to add instructor.");
                    Console.WriteLine("------------------------------------------");
                }

                Console.WriteLine("Do you want to add another one? Y or N ");
                Console.WriteLine("------------------------------------------");

                userChoice = Console.ReadLine().ToLower();
            }
            while (userChoice != "n");

        }
        public static void CreateCoursesTable()
        {
            string courseName, userChoice;
            int instructorId;
            do
            {
                Console.WriteLine("Enter the course name :");
                courseName = Console.ReadLine();
                Console.WriteLine("Enter the instructor id :");
                instructorId = Convert.ToInt32(Console.ReadLine());
                if (CourseManager.AddCourse(courseName, instructorId))
                {
                    Console.WriteLine("------------------------------------------");

                    Console.WriteLine("Course added successfully.");
                    Console.WriteLine("------------------------------------------");

                }
                else
                {
                    Console.WriteLine("------------------------------------------");

                    Console.WriteLine("Failed to add course.");
                    Console.WriteLine("------------------------------------------");

                }
                Console.WriteLine("Do you want to add another one? Y or N ");
                Console.WriteLine("------------------------------------------");

                userChoice = Console.ReadLine().ToLower();
            }
            while (userChoice != "n");
        }
        public static void CreateStudentsTable()
        {
            string name, userChoice;
            int age;
            do
            {
                Console.WriteLine("Enter the name :");
                name = Console.ReadLine();
                Console.WriteLine("Enter the age :");
                age = Convert.ToInt32(Console.ReadLine());
                if (StudentManager.AddStudent(name, age))
                {
                    Console.WriteLine("------------------------------------------");

                    Console.WriteLine("Student added successfully.");
                    Console.WriteLine("------------------------------------------");

                }
                else
                {
                    Console.WriteLine("------------------------------------------");

                    Console.WriteLine("Failed to add student.");
                    Console.WriteLine("------------------------------------------");
                }
                Console.WriteLine("Do you want to add another one? Y or N ");
                Console.WriteLine("------------------------------------------");
                userChoice = Console.ReadLine().ToLower();
            }
            while (userChoice != "n");
        }

        public static void PrintInstructorsTable()
        {
            foreach (var instructor in Database.Instructors)
            {
                Console.WriteLine($"Id: {instructor.Id}, Name: {instructor.Name}, Specialization: {instructor.Specialization}");
            }
        }
        public static void PrintCoursessTable()
        {
            foreach (var course in Database.Courses)
            {
                Console.WriteLine($"Id: {course.Id}, Course Name: {course.Name}, Instructor id: {course.InstructorId}");
            }
        }
        public static void PrintStudentsTable()
        {
            foreach (var student in Database.Students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name} ,Age: {student.Age}, Enrolled courses: {student.EnrolledCourses.Count}");
            }
        }

        public static void ChoicesForStudent(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter student name:");
                    string studentName = Console.ReadLine();
                    Console.WriteLine("Enter course name:");
                    string courseName = Console.ReadLine();
                    if (CourseManager.EnrollStudentInCourse(studentName, courseName))
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Student enrolled in course successfully.");
                        Console.WriteLine("------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Failed to enroll student in course.");
                        Console.WriteLine("------------------------------------------");
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter student name:");
                    string name = Console.ReadLine();
                    var courses = StudentManager.GetEnrolledCourses(name);
                    if (courses != null && courses.Count > 0)
                    {
                        Console.WriteLine($"Enrolled courses for {name}:");
                        foreach (var course in courses)
                        {
                            Console.WriteLine($"- {course.Name}, {course.InstructorId}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No enrolled courses found for {name}.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter student name:");
                    string Name = Console.ReadLine();
                    Console.WriteLine("Enter course name:");
                    string CourseName = Console.ReadLine();

                    if (StudentManager.IsStudentEnrolledInCourse(Name, CourseName))
                    {
                        Console.WriteLine($"Yes, {Name} is enrolled in {CourseName}.");
                    }
                    else
                    {
                        Console.WriteLine($"No, {Name} is not enrolled in {CourseName}.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter student ID:");
                    int studentId = Convert.ToInt32(Console.ReadLine());
                    var studentById = StudentManager.FindStudentById(studentId);
                    if (studentById != null)
                    {
                        Console.WriteLine($"Student found: Id: {studentById.Id}, Name: {studentById.Name}, Age: {studentById.Age}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter student name:");
                    string studentNameSearch = Console.ReadLine();
                    var studentByName = StudentManager.FindStudentByName(studentNameSearch);
                    if (studentByName != null)
                    {
                        Console.WriteLine($"Student found: Id: {studentByName.Id}, Name: {studentByName.Name}, Age: {studentByName.Age}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found.");
                    }
                    break;
                case 6:
                    Console.WriteLine("Enter student name:");
                    string newStudentName = Console.ReadLine();
                    Console.WriteLine("Enter student age:");
                    int newStudentAge = Convert.ToInt32(Console.ReadLine());
                    if (StudentManager.AddStudent(newStudentName, newStudentAge))
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Student added successfully.");
                        Console.WriteLine("------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Failed to add student.");
                        Console.WriteLine("------------------------------------------");
                    }
                    break;
                case 7:
                    Console.WriteLine("Enter student ID to remove:");
                    int removeStudentId = Convert.ToInt32(Console.ReadLine());
                    if (StudentManager.RemoveStudent(removeStudentId))
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Student removed successfully.");
                        Console.WriteLine("------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Failed to remove student.");
                        Console.WriteLine("------------------------------------------");
                    }
                    break;
                case 8:
                    var allStudents = StudentManager.GetAllStudents();
                    if (allStudents != null && allStudents.Count > 0)
                    {
                        Console.WriteLine("All Students:");
                        foreach (var student in allStudents)
                        {
                            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, Enrolled courses : {student.EnrolledCourses.Select(s=> s.Name)}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No students found.");
                    }
                    break;
                default:
                    break;

            }
        }
        public static void ChoicesForInstructor(int choice)
        {
            
            switch (choice)
            {
                //case 9:
                //    Console.WriteLine("Enter instructor name:");
                //    string instructorName = Console.ReadLine();
                //    Console.WriteLine("Enter course name:");
                //    string courseName = Console.ReadLine();
                //    if (CourseManager.AssignCourseToInstructor(instructorName, courseName))
                //    {
                //        Console.WriteLine("------------------------------------------");
                //        Console.WriteLine("Course assigned to instructor successfully.");
                //        Console.WriteLine("------------------------------------------");
                //    }
                //    else
                //    {
                //        Console.WriteLine("------------------------------------------");
                //        Console.WriteLine("Failed to assign course to instructor.");
                //        Console.WriteLine("------------------------------------------");
                //    }
                //    break;
                case 10:
                    Console.WriteLine("Enter instructor name:");
                    string name = Console.ReadLine();
                    var instructorByName = InstructorManager.FindInstructorByName(name);
                    if (instructorByName != null)
                    {
                        Console.WriteLine($"Instructor found: Id: {instructorByName.Id}, Name: {instructorByName.Name}, Specialization: {instructorByName.Specialization}");
                    }
                    else
                    {
                        Console.WriteLine("Instructor not found.");
                    }
                    break;
                case 11:
                    Console.WriteLine("Enter instructor ID:");
                    int instructorId = Convert.ToInt32(Console.ReadLine());
                    var instructorById = InstructorManager.FindInstructorById(instructorId);
                    if (instructorById != null)
                    {
                        Console.WriteLine($"Instructor found: Id: {instructorById.Id}, Name: {instructorById.Name}, Specialization: {instructorById.Specialization}");
                    }
                    else
                    {
                        Console.WriteLine("Instructor not found.");
                    }
                    break;
                case 12:
                    Console.WriteLine("Enter course name:");
                    string crsName = Console.ReadLine();
                    var instructorByCourse = InstructorManager.FindInstructorByCourse(crsName);
                    if (instructorByCourse != null)
                    {
                        Console.WriteLine($"Instructor found: Id: {instructorByCourse.Id}, Name: {instructorByCourse.Name}, Specialization: {instructorByCourse.Specialization}");
                    }
                    else
                    {
                        Console.WriteLine("Instructor not found.");
                    }
                    break;
                case 13:
                    Console.WriteLine("Enter instructor name:");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter specialization:");
                    string specialization = Console.ReadLine();
                    var instructorBySpecialization = InstructorManager.FindBySpecialization(specialization);
                    if (InstructorManager.FindBySpecialization(specialization) != null)
                    {
                        Console.WriteLine($"Instructor found: Id: {instructorBySpecialization.Id}, Name: {instructorBySpecialization.Name}, Specialization: {instructorBySpecialization.Specialization}");
                    }
                    else
                    {
                        Console.WriteLine("Instructor not found.");
                    }
                    break;
                case 14:
                    Console.WriteLine("Enter instructor name:");
                    string newInstructorName = Console.ReadLine();
                    Console.WriteLine("Enter specialization:");
                    string newInstructorSpecialization = Console.ReadLine();
                    if (InstructorManager.AddInstructor(newInstructorName, newInstructorSpecialization))
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Instructor added successfully.");
                        Console.WriteLine("------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Failed to add instructor.");
                        Console.WriteLine("------------------------------------------");
                    }
                    break;
                case 15:
                    Console.WriteLine("Enter instructor ID to remove:");
                    int removeInstructorId = Convert.ToInt32(Console.ReadLine());
                    if (InstructorManager.RemoveInstructor(removeInstructorId))
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Instructor removed successfully.");
                        Console.WriteLine("------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Failed to remove instructor.");
                        Console.WriteLine("------------------------------------------");
                    }
                    break;
                case 16:
                    var allInstructors = InstructorManager.GetAllInstructors();
                    if (allInstructors != null && allInstructors.Count > 0)
                    {
                        Console.WriteLine("All Instructors:");
                        foreach (var instructor in allInstructors)
                        {
                            Console.WriteLine($"Id: {instructor.Id}, Name: {instructor.Name}, Specialization: {instructor.Specialization}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No instructors found.");
                    }
                    break;
                default:
                    break;
            }
        }

        public static void ChoicesForCourse(int choice)
        {
            switch (choice)
            {
                case 17:
                    Console.WriteLine("Enter course name:");
                    string courseName = Console.ReadLine();
                    var courseByName = CourseManager.FindCourseByName(courseName);
                    if (courseByName != null)
                    {
                        Console.WriteLine($"Course found: Id: {courseByName.Id}, Name: {courseByName.Name}, InstructorId: {courseByName.InstructorId}");
                    }
                    else
                    {
                        Console.WriteLine("Course not found.");
                    }
                    break;
                case 18:
                    Console.WriteLine("Enter course ID:");
                    int courseId = Convert.ToInt32(Console.ReadLine());
                    var courseById = CourseManager.FindCourseById(courseId);
                    if (courseById != null)
                    {
                        Console.WriteLine($"Course found: Id: {courseById.Id}, Name: {courseById.Name}, InstructorId: {courseById.InstructorId}");
                    }
                    else
                    {
                        Console.WriteLine("Course not found.");
                    }
                    break;
                case 19:
                    Console.WriteLine("Enter course name:");
                    string newCourseName = Console.ReadLine();
                    Console.WriteLine("Enter instructor ID:");
                    int instructorId = Convert.ToInt32(Console.ReadLine());
                    if (CourseManager.AddCourse(newCourseName, instructorId))
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Course added successfully.");
                        Console.WriteLine("------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Failed to add course.");
                        Console.WriteLine("------------------------------------------");
                    }
                    break;
                case 20:
                    Console.WriteLine("Enter course ID to remove:");
                    int removeCourseId = Convert.ToInt32(Console.ReadLine());
                    if (CourseManager.RemoveCourse(removeCourseId))
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Course removed successfully.");
                        Console.WriteLine("------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Failed to remove course.");
                        Console.WriteLine("------------------------------------------");
                    }
                    break;
                case 21:
                    var allCourses = CourseManager.GetAllCourses();
                    if (allCourses != null && allCourses.Count > 0)
                    {
                        foreach (var course in allCourses)
                        {
                            Console.WriteLine($"Id: {course.Id}, Name: {course.Name}, InstructorId: {course.InstructorId}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No courses found.");
                    }
                    break;
                case 22:
                    break;
                default:
                    break;
            }
        }
    }
}