using System;
using System.Collections.Generic;
 
namespace Problem2_Dictionary
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }
 
    class Program
    {
        static Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();
 
        static void Main()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("STUDENT LOOKUP USING DICTIONARY");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Display All Students");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();
 
                switch (choice)
                {
                    case "1": AddStudent(); break;
                    case "2": SearchStudent(); break;
                    case "3": DisplayAll(); break;
                    case "4":
                        Console.WriteLine("Program exited.");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine();
            }
        }
 
        static int ReadYearLevel()
        {
            while (true)
            {
                Console.Write("Enter Year Level (1-4): ");
                if (int.TryParse(Console.ReadLine(), out int year) && year >= 1 && year <= 4)
                    return year;
                Console.WriteLine("Invalid year level. Enter 1, 2, 3, or 4.");
            }
        }
 
        static void PrintStudent(Student s)
        {
            Console.WriteLine("Student Number: " + s.StudentNumber);
            Console.WriteLine("Name: " + s.Name);
            Console.WriteLine("Program: " + s.Program);
            Console.WriteLine("Year Level: " + s.YearLevel);
        }
 
        static void AddStudent()
        {
            Student s = new Student();
            Console.Write("Enter Student Number: ");
            s.StudentNumber = Console.ReadLine().Trim();
 
            // Prevent duplicate Student Numbers (the key)
            if (studentDictionary.ContainsKey(s.StudentNumber))
            {
                Console.WriteLine("Student Number already exists. Duplicate not allowed.");
                return;
            }
 
            Console.Write("Enter Name: ");
            s.Name = Console.ReadLine();
            Console.Write("Enter Program: ");
            s.Program = Console.ReadLine();
            s.YearLevel = ReadYearLevel();
 
            studentDictionary.Add(s.StudentNumber, s);
            Console.WriteLine("Student added successfully!");
        }
 
        static void SearchStudent()
        {
            Console.Write("Enter Student Number to search: ");
            string key = Console.ReadLine().Trim();
 
            if (studentDictionary.TryGetValue(key, out Student s))
            {
                Console.WriteLine("Student Found!");
                PrintStudent(s);
            }
            else
            {
                Console.WriteLine("Student Number not found.");
            }
        }
 
        static void DisplayAll()
        {
            if (studentDictionary.Count == 0)
            {
                Console.WriteLine("No student records found.");
                return;
            }
 
            Console.WriteLine("========================================");
            Console.WriteLine("STUDENT RECORDS");
            Console.WriteLine("========================================");
            foreach (KeyValuePair<string, Student> entry in studentDictionary)
            {
                PrintStudent(entry.Value);
                Console.WriteLine();
            }
        }
    }
}
 
