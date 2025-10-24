using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem
{
    internal class QuestionFactory
    {
        public static Question CreateQuestion()
        {
            Console.WriteLine("Enter the question text");
            string text = Console.ReadLine();

            Console.WriteLine("Enter question difficulty {Easy, Medium, Hard}:");
            string difficulty = Console.ReadLine();

            Console.WriteLine("Enter number of choices:");
            int numChoices = Convert.ToInt32(Console.ReadLine());

            string[] choices = new string[numChoices];
            for (int i = 0; i < numChoices; i++)
            {
                Console.WriteLine($"Enter choice {i + 1}:");
                choices[i] = Console.ReadLine();
            }

            Console.WriteLine("Enter the correct answer:");
            string answer = Console.ReadLine();

            int points = difficulty.ToLower() switch
            {
                "easy" => 5,
                "medium" => 10,
                "hard" => 15,
                _ => 5
            };



            return new Question
            {
                Text = text,
                Difficulty = difficulty,
                Points = points, // Points can be set later if needed
                Choices = choices,
                Answer = answer
            };
        }
    }
}
