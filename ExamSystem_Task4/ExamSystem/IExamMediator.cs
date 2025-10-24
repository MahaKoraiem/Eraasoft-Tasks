using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ExamSystem.AuthValidationHnadler;

namespace ExamSystem
{
    internal interface IExamMediator
    {
        void RegisterTeacherObserver(ITeacherObserver observer);
        void CreateTest(UserContext user, Test test);
        void StartTest(UserContext user, Test test);
        List<Test> QueryTests(string difficulty);
    }




    internal class ExamMediator : IExamMediator
    {
        private readonly ITestRepository _repo;
        private readonly ValidationHandler _createChain;
        private readonly ValidationHandler _startChain;

        public ExamMediator(ITestRepository repo)
        {
            _repo = repo;
            _createChain = new AuthValidationHnadler(UserRole.Instructor);
            _startChain = new StudentHasAccessHandler();
            _startChain.SetNext(new TestNotEmptyHandler());
        }
        public void CreateTest(UserContext user, Test test)
        {
            var result = new RequestContext()
            {
                User = user,
                test = test,
                Action = "create"
            };

            if(!_createChain.Handle(result))
            {
                Console.WriteLine($"{result.MessageIfFailed}: Failed to create test");
                return;
            }
            var proxy = new TestRepositoryProxy(user);
            proxy.AddTest(test);
            Console.WriteLine("Test created successfully.");
            //TestManager.Instance().NotifyStudents($"A new Exam has been created '{test.Title}' By {user.Name}");
        }

        public List<Test> QueryTests(string difficulty)
        {
            return _repo.GetTestsByDifficulty(difficulty);
        }

        public void RegisterTeacherObserver(ITeacherObserver observer)
        {
            TestManager.Instance().teachersObservers.Add(observer);
        }

        public void StartTest(UserContext user, Test test)
        {
            var result = new RequestContext()
            {
                User = user,
                test = test,
                Action = "start"
            };

            if (!_startChain.Handle(result))
            {
                Console.WriteLine($"{result.MessageIfFailed}: Failed to start test");
                return;
            }
            Console.WriteLine($"starting Exam: {test.Title}");

            var answers = new List<string>();
            foreach (var q in test.Questions)
            {
                Console.WriteLine(q.Text);
                for (int i = 0; i < q.Choices.Length; i++)
                {
                    Console.WriteLine($"-. {q.Choices[i]}");
                }
                Console.Write("your answer: ");
                string a = Console.ReadLine();
                    answers.Add(a);
            }

            IScoringStrategy scoring = new SimpleScoring();
            var studentScore = scoring.CalculateScore(test, answers);
            var percent = test.TotalPoints == 0 ? 0 : (double)studentScore / test.TotalPoints * 100;
            Console.WriteLine($"Your score is {studentScore} out of {test.TotalPoints} ({percent:F2}%)");
            //TestManager.Instance().NotifyStudents(result.User.Name,$"You completed '{test.Title}' successfully and scored {studentScore}!");
            //TestManager.Instance().NotifyTeachers($"Student: {user.Name} finished test: '{test.Title}' with percentage {percent:F2}%.");
        }

        
    }
}
