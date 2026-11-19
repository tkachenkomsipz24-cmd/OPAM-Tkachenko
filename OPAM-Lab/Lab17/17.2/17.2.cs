using System;

namespace ConsoleApp
{
    struct Student
    {
        public string lastName;
        public int totalScore;
        public void Info()
        {
            Console.WriteLine($"Студент: {lastName} | Сума балів: {totalScore}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student;

            student.lastName = "Ткаченко";
            student.totalScore = 95;

            student.Info();
        }
    }
}