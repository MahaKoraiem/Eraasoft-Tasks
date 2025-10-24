using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal class Test
    {
        public string Title { get; set; }
        public string Difficulty { get; set; }
        //public string CreatedBy { get; set; }
        public List<Question> Questions { get; set; } = new List<Question>();
        public int TotalPoints => Questions.Sum(q=> q.Points);
        public Test()
        {
            
        }
    }
}
