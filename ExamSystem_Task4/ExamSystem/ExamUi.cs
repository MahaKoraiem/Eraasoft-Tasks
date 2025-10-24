using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal class ExamUi
    {
        public IExamMediator Mediator { get; }
        public UserContext CurrentUser { get; private set; } = new UserContext { Role = UserRole.Guest };

        public ExamUi(IExamMediator mediator)
        {
            Mediator = mediator;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Instructor Mode");
                Console.WriteLine("2. Student Mode");
                Console.WriteLine("3. Show all exams");
                Console.WriteLine("4. Login (Instructor/Student)");
                Console.WriteLine("5. Exit");
                Console.Write("Your Choice : ");
                var c = Console.ReadLine();
                switch (c)
                {
                    case "1": new EnterTeacherModeCommand(this).Execute(); break;
                    case "2": new EnterStudentModeCommand(this).Execute(); break;
                    case "3": ListAllTests(); break;
                    case "4": Login(); break;
                    case "5": return;
                    default: Console.WriteLine("Invalid Choice.. Try Again"); break;
                }
            }
        }

        public void Login()
        {
            Console.Write("User name: ");
            var name = Console.ReadLine();
            Console.Write("Choose your role (student/instructor): ");
            var role = Console.ReadLine();
            if (role.ToLower() == "instructor")
            {
                CurrentUser = new UserContext { Name = name, Role = UserRole.Instructor };
                
                TestManager.Instance().NotifyTeachers(CurrentUser.Name,$"You logged in as a {CurrentUser.Role} with name {CurrentUser.Name}");

            }
            else if(role.ToLower() == "student")
            {
                CurrentUser = new UserContext { Name = name, Role = UserRole.Student };
                TestManager.Instance().NotifyStudents(CurrentUser.Name, $"You logged in as a {CurrentUser.Role} with name {CurrentUser.Name}");

                //TestManager.Instance().NotifyTeachers($"You logged in as a {CurrentUser.Role} with name {CurrentUser.Name}");

            }

            //Console.WriteLine($"You logged in as a {CurrentUser.Role} with name {CurrentUser.Name}");
        }

        public void ShowTeacherMenu()
        {
            if (CurrentUser.Role != UserRole.Instructor) 
                Console.WriteLine("Warning!!! You must login as an instructor first in order to show the sub menu!!");
            else
            {
                while (true)
                {
                    Console.WriteLine("***** Teacher menu *****");
                    Console.WriteLine("1. Register a new Instructor (Observer)");
                    Console.WriteLine("2. Create an Exam");
                    Console.WriteLine("3. Show notifications");
                    Console.WriteLine("4. Back to main menu");
                    Console.Write("Your choice : ");
                    var choice = Console.ReadLine();
                
                    ICommand cmd = choice switch
                    {
                        "1" => new RegisterTeacherCommand(this),
                        "2" => new CreateExamCommand(this),
                        "3" => new ShowNotificationsCommand(this),
                        _ => new BackToMainMenuCommand()
                    };
                    cmd.Execute();
                    if (choice == "4") break;
                
                }

            }
        }

        public void ShowStudentMenu()
        {
            if(CurrentUser.Role != UserRole.Student)
                Console.WriteLine("Warning!!! You must login as a student first in order to show the sub menu!!");
            else
            {
                 while (true)
                 {
                    Console.WriteLine("Student Menu");
                    Console.WriteLine("1. Show all exams based on difficulty");
                    Console.WriteLine("2. Start an exam");
                    Console.WriteLine("3. Show notifications");
                    Console.WriteLine("4. Back to main menu");
                    Console.Write("Your choice: ");
                    var choice = Console.ReadLine();
                
                    ICommand cmd = choice switch
                    {
                        "1" => new ListTestsCommand(this),
                        "2" => new StartTestCommand(this),
                        "3" => new ShowNotificationsCommand(this),
                        _ => new BackToMainMenuCommand()
                    };
                    cmd.Execute();
                    if (choice == "3") break;
                
                 }
            }
        }

        public void ListAllTests()
        {
            var repo = new TestRepositoryProxy(CurrentUser);
            var all = repo.GetAllTests();
            if (all.Count == 0) 
            { 
                Console.WriteLine("No available exams right now.");
                return;
            }
            Console.WriteLine("All availbale exams : ");
            for (int i = 0; i < all.Count; i++)
                Console.WriteLine($"{i + 1}. {all[i].Title} - {all[i].Difficulty} - {all[i].TotalPoints} Points");
        }
    }
}
