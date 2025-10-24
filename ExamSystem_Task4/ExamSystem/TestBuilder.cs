using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal class TestBuilder
    {
        private Test _test = new Test();

        public static TestBuilder Empty()=> new TestBuilder();

        public  TestBuilder WithTitle(string title)
        {
            _test.Title = title;
            return this;
        }

        public  TestBuilder WithDifficulty(string difficulty)
        {
            _test.Difficulty = difficulty;
            return this;
        }

        public  TestBuilder WithQuestion(Question question)
        {
            _test.Questions.Add(question);
            return this;
        }

        public  Test Build()
        {
            return _test;
        }
    }
}
