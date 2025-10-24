using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal interface ITestRepository
    {
        void AddTest(Test test);
        List<Test> GetAllTests();
        List<Test> GetTestsByDifficulty(string difficulty);
    }




    internal class TestRepository : ITestRepository
    {

        public void AddTest(Test test)
        {
            TestManager.Instance().AddTest(test);
        }

        public List<Test> GetAllTests()
        {
            return TestManager.Instance().GetAllTests();
        }

        public List<Test> GetTestsByDifficulty(string difficulty)
        {
            return TestManager.Instance().GetTestsByDifficulty(difficulty);
        }
    }


    internal class TestRepositoryProxy : ITestRepository
    {
        private readonly TestRepository _testRepository = new TestRepository();
        private readonly UserContext _userContext = new UserContext();

        public TestRepositoryProxy(UserContext user)
        {
            _userContext = user;
        }

        public void AddTest(Test test)
        {
            if(_userContext.IsInRole(UserRole.Instructor))
            {
                _testRepository.AddTest(test);
            }
            else
            {
                Console.WriteLine("Only teachers can add tests.");
            }
        }

        public List<Test> GetAllTests()
        {
            return _testRepository.GetAllTests();
        }

        public List<Test> GetTestsByDifficulty(string difficulty)
        {
            return _testRepository.GetTestsByDifficulty(difficulty);
        }
    }
}
