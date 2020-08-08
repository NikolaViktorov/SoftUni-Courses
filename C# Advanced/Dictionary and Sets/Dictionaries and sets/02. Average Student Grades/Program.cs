using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < numOfStudents; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string student = input[0];
                double grade = double.Parse(input[1]);

                if (students.ContainsKey(student) == true)
                {
                    students[student].Add(grade);
                }
                else
                {
                    students.Add(student, new List<double>());
                    students[student].Add(grade);
                }
            }
            foreach (KeyValuePair<string, List<double>> student in students)
            {
                Console.Write($"{student.Key} -> ");
                student.Value.ForEach(x => Console.Write($"{x:F2} "));
                Console.Write($"(avg: {student.Value.Average():F2})");
                Console.WriteLine();
            }
        }
    }
}
