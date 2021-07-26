using System;
using System.Collections;
using System.Collections.Generic;

namespace Participation
{
    class Program
    {
        /*Ask the user to enter all of their exam grades.  
         * Once they are done, calculate the minimum score, the maximum score 
         * and the average score for all of their scores.  
         * Perform this using at least 2 Loops (can be the same type of loop) and not any built in functions.
         * Extra: Use a dictionary and count the Mode
         */
        static void Main(string[] args)
        {
            List<double> examGrades = new List<double>();
            Dictionary<double, int> findingMode = new Dictionary<double, int>();

            string loopAgain;

            do
            {
                double grade;
                Console.WriteLine("Please enter your exam grade.>>");
                string exam = Console.ReadLine();

                while (double.TryParse(exam, out grade) == false)
                {
                    Console.WriteLine("Please input a number for your grade.");
                    exam = Console.ReadLine();
                }

                examGrades.Add(grade);

                if (findingMode.ContainsKey(grade) == false)
                {
                    findingMode.Add(grade, 1);
                }
                else
                {
                    findingMode[grade] = findingMode[grade] + 1;
                }


                Console.WriteLine("Would you like to enter another grade?>>");
                loopAgain = Console.ReadLine().ToLower();

            } while (loopAgain.ToLower()[0] == 'y');

            double min = examGrades[0];
            double max = examGrades[0];
            double average = 0;

            foreach (double grade in examGrades)
            {
                if (grade < min)
                {
                    min = grade;
                }
                if (grade > max)
                {
                    max = grade;
                }

                average = average + grade / examGrades.Count;
            }

            int maxTimes = 0;
            double mode = 0;

            foreach (double key in findingMode.Keys)
            {
                double grade = key;

                if (findingMode[grade] > maxTimes)
                {
                    maxTimes = findingMode[grade];
                    mode = key;
                }
            }
            foreach (double key in findingMode.Keys)
            {
                double grade = key;
                if (findingMode[grade] == maxTimes)
                {
                    Console.WriteLine($"The grade that appears the most times is {grade} x {maxTimes}.");
                }
            }

            Console.WriteLine($"Your minimum grade is: {min}");
            Console.WriteLine($"Your maximum grade is: {max}");
            Console.WriteLine($"Your average is: {average.ToString("N2")}");
            Console.WriteLine($"Your mode is: {mode.ToString("N2")}");
        }
    }
}
