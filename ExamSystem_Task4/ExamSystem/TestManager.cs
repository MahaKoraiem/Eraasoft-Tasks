using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    sealed class TestManager
    {
        private static TestManager _Instance;
        private static readonly object _lock = new object();
        private static readonly List<Test> tests = new List<Test>();
        public readonly List<ITeacherObserver> teachersObservers = new List<ITeacherObserver>();
        public readonly List<ITeacherObserver> studentsObservers = new List<ITeacherObserver>();
        public static TestManager Instance()
        {
            if (_Instance == null)
            {
                lock (_lock)
                {
                    if (_Instance == null)
                    {
                        _Instance = new TestManager();
                    }
                }
            }
            return _Instance;
        }


        private TestManager() { }


        public bool AddTest(Test test)
        {
            if(test != null)
            {
                tests.Add(test);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Test> GetAllTests()
        {
            return tests;
        }

        public List<Test> GetTestsByDifficulty(string difficulty)
        {
            return tests.Where(tests => tests.Difficulty.Equals(difficulty, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void NotifyTeachers(dynamic username,string message)
        {
            NotificationCenter.Instance.AddNotification(username,message);
            foreach (var observer in teachersObservers)
            {
                observer.Update(message);
            }
        }

        public void NotifyStudents(dynamic username,string message)
        {
            NotificationCenter.Instance.AddNotification(username, message);
        }

        public List<ITeacherObserver> GetAllTeacherObservers()
        {
            return teachersObservers;
        }
    }
}
