namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StudentSystem
    {
        private Dictionary<string, Student> students;

        public StudentSystem()
        {
            this.Students = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Students
        {
            get { return students; }
            private set { students = value; }
        }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();
            string command = args[0];

            if (command == "Create")
            {
                string name = args[1];
                int age = int.Parse(args[2]);
                double grade = double.Parse(args[3]);
                Create(name, age, grade);
            }
            else if (command == "Show")
            {
                var name = args[1];
                Show(name);
            }
            else if (command == "Exit")
            {
                Environment.Exit(0);
            }
        }
        public void Show (string name)
        {
            if (Students.ContainsKey(name))
            {
                Student student = Students[name];
                StringBuilder result = new StringBuilder();
                result.Append($"{student.Name} is {student.Age} years old.");

                if (student.Grade >= 5.00)
                {
                    result.Append(" Excellent student.");
                }
                else if (student.Grade < 5.00 && student.Grade >= 3.50)
                {
                    result.Append(" Average student.");
                }
                else
                {
                    result.Append(" Very nice person.");
                }

                Console.WriteLine(result.ToString());
            }
        }
        public void Create(string studentName, int studentAge, double studentGrade)
        {
             Student student = new Student(studentName, studentAge, studentGrade);
             Students[studentName] = student;     
        }
    }

    public class Student
    {
        private string name;
        private int age;
        private double grade;

        public double Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.grade = grade;
        }
    }
}