using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal interface ICommand
    {
        void Execute();
    }


    internal class EnterTeacherModeCommand : ICommand
    {
        private readonly ExamUi _ui;
        public EnterTeacherModeCommand(ExamUi ui) { _ui = ui; }
        public void Execute() => _ui.ShowTeacherMenu();
    }

    internal class EnterStudentModeCommand : ICommand
    {
        private readonly ExamUi _ui;
        public EnterStudentModeCommand(ExamUi ui) { _ui = ui; }
        public void Execute() => _ui.ShowStudentMenu();
    }




    internal class RegisterTeacherCommand : ICommand
    {
        private readonly ExamUi _ui;
        public RegisterTeacherCommand(ExamUi ui) { _ui = ui; }
        public void Execute()
        {
            Console.Write("Enter instructor name: ");
            var name = Console.ReadLine();
            var t = new Teacher(name);
            _ui.Mediator.RegisterTeacherObserver(t);
            Console.WriteLine($"Instructor: {name} registered successfully");
            
        }
    }


    internal class CreateExamCommand : ICommand
    {
        private readonly ExamUi _ui;
        public CreateExamCommand(ExamUi ui) { _ui = ui; }
        public void Execute()
        {
            Console.Write("Enter Test Title: ");
            var title = Console.ReadLine();
            Console.Write("Choose Difficulty (Easy/medium/hard): ");
            var diff = Console.ReadLine();
            Console.Write("Enter number of questions: ");
            int count = Convert.ToInt32(Console.ReadLine());

            var builder = new TestBuilder().WithTitle(title).WithDifficulty(diff);

            for (int i = 0; i < count; i++)
            {
                var q = QuestionFactory.CreateQuestion();
                builder.WithQuestion(q);
            }
            var test = builder.Build();
            _ui.Mediator.CreateTest(_ui.CurrentUser, test);

            TestManager.Instance().NotifyTeachers(_ui.CurrentUser.Name,$"You created a new exam: {test.Title} in {DateOnly.FromDateTime(DateTime.Now)}");
            //TestManager.Instance().NotifyStudents(,$"a new exam is created: {test.Title} by: {_ui.CurrentUser.Name} in {DateOnly.FromDateTime(DateTime.Now)}");
            //NotificationCenter.Instance.AddNotification($"You created a new test in: {DateOnly.FromDateTime(DateTime.Now)}");

        }
    }

    internal class ShowNotificationsCommand : ICommand
    {
        private readonly ExamUi _ui;

        public ShowNotificationsCommand(ExamUi ui)
        {
            _ui = ui;
        }
        public  void Execute()
        {
            var notifs = NotificationCenter.Instance.GetNotifications(_ui.CurrentUser.Name);
            if (notifs.Count == 0) Console.WriteLine("No notifications yet.");
            else foreach (var n in notifs) Console.WriteLine(n);

        }
    }

    internal class ListTestsCommand : ICommand
    {
        private readonly ExamUi _ui;
        public ListTestsCommand(ExamUi ui) { _ui = ui; }
        public void Execute()
        {
            Console.Write("Enter the test difficulty: ");
            var diff = Console.ReadLine();
            var tests = _ui.Mediator.QueryTests(diff);
            if (tests.Count == 0) { Console.WriteLine("404 Not Found"); return; }
            for (int i = 0; i < tests.Count; i++)
                Console.WriteLine($"{i + 1}. {tests[i].Title} - {tests[i].TotalPoints} points");
        }
    }

    internal class StartTestCommand : ICommand
    {
        private readonly ExamUi _ui;
        public StartTestCommand(ExamUi ui) { _ui = ui; }
        public void Execute()
        {
            Console.Write("Enter the test difficulty: ");
            var diff = Console.ReadLine();
            var tests = _ui.Mediator.QueryTests(diff);

            if (tests.Count == 0)
            {
                Console.WriteLine("404 Not Found");
                return;
            }

            for (int i = 0; i < tests.Count; i++) Console.WriteLine($"{i + 1}. {tests[i].Title}");
            Console.Write("Enter test number: ");
            int testNumber = Convert.ToInt32(Console.ReadLine());
            if(testNumber > tests.Count)
            {
                Console.WriteLine("Inavalid Choice!!");
                return; 
            }
            var test = tests[testNumber - 1];
            _ui.Mediator.StartTest(_ui.CurrentUser, test);
            

        }
    }

    public class BackToMainMenuCommand : ICommand
    { 
        public void Execute() { }
    }
}
