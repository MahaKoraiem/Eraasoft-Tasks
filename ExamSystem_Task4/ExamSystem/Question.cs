using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal class Question
    {
        public string Text { get; set; }
        public string Difficulty { get; set; }
        public int Points { get; set; }
        public string[] Choices { get; set; }
        public string Answer { get; set; }

    }
}
