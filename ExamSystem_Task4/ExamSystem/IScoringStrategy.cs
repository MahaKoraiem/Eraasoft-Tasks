using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal interface IScoringStrategy
    {
        int CalculateScore(Test test, List<string> answers);
    }


    internal class SimpleScoring : IScoringStrategy
    {
        public int CalculateScore(Test test, List<string> answers)
        {
            int score = 0;

            for (int i = 0; i < test.Questions.Count; i++)
            {
                if (answers[i].Equals(test.Questions[i].Answer, StringComparison.OrdinalIgnoreCase))
                {
                    score += test.Questions[i].Points;
                }
            }

            return score;
        }
    }
}
