
using System;
using System.Collections.Generic;
 
namespace Problem4_Stack
{
    struct Student
    {
        public string StudentNumber;
        public string Name;
        public string Program;
        public int YearLevel;
    }
 
    struct Operation
    {
        public string Action;
        public string StudentNumber;
        public string StudentName;
    }
 
    class Program
    {
        const int MaxStudents = 10;
        static Student[] students = new Student[MaxStudents];
        static int studentCount = 0;
        static Stack<Operation> operationHistory = new Stack<Operation>();
 
        static void Main()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("OPERATION HISTORY");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Display All Students");
                Console.WriteLine("5. View Operation History");
                Console.WriteLine("6. View Last Operation");
                Console.WriteLine("7. Remove Last Operation");
                Console.WriteLine("8. Exit");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();
 
                switch (choice)
                {
                    case "1": AddStudent(); break;
                    case "2": UpdateStudent(); break;
                    case "3": DeleteStudent(); break;
                    case "4": DisplayAll(); break;
                    case "5": ViewHistory(); break;
                    case "6": ViewLastOperation(); break;
                    case "7": RemoveLastOperation(); break;
                    case "8":
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
 
        // ---------- Helpers ----------
        static int FindIndex(string studentNumber)
        {
            for (int i = 0; i < studentCount; i++)
            {
                if (students[i].StudentNumber == studentNumber)
                    return i;
            }
            return -1;
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
 
        static void RecordOperation(string action, Student s)
        {
            Operation op = new Operation();
            op.Action = action;
            op.StudentNumber = s.StudentNumber;
            op.StudentName = s.Name;
            operationHistory.Push(op); // newest operation sits on top
        }
 
        // ---------- Student operations (each one records to the stack) ----------
        static void AddStudent()
        {
            if (studentCount >= MaxStudents)
            {
                Console.WriteLine("Cannot add more students. The array is full (max 10).");
                return;
            }
 
            Student s = new Student();
            Console.Write("Enter Student Number: ");
            s.StudentNumber = Console.ReadLine().Trim();
 
            if (FindIndex(s.StudentNumber) != -1)
            {
                Console.WriteLine("Student Number already exists.");
                return;
            }
 
            Console.Write("Enter Name: ");
            s.Name = Console.ReadLine();
            Console.Write("Enter Program: ");
            s.Program = Console.ReadLine();
            s.YearLevel = ReadYearLevel();
 
            students[studentCount] = s;
            studentCount++;
            RecordOperation("Added", s);
            Console.WriteLine("Student added successfully!");
        }
 
        static void UpdateStudent()
        {
            Console.Write("Enter Student Number to update: ");
            int index = FindIndex(Console.ReadLine().Trim());
 
            if (index == -1)
            {
                Console.WriteLine("Student not found.");
                return;
            }
 
            Student s = students[index];
            Console.Write("Enter new Name: ");
            s.Name = Console.ReadLine();
            Console.Write("Enter new Program: ");
            s.Program = Console.ReadLine();
            s.YearLevel = ReadYearLevel();
 
            students[index] = s;
            RecordOperation("Updated", s);
            Console.WriteLine("Student updated successfully!");
        }
 
        static void DeleteStudent()
        {
            Console.Write("Enter Student Number to delete: ");
            int index = FindIndex(Console.ReadLine().Trim());
 
            if (index == -1)
            {
                Console.WriteLine("Student not found.");
                return;
            }
 
            Student deleted = students[index];
 
            for (int i = index; i < studentCount - 1; i++)
                students[i] = students[i + 1];
 
            students[studentCount - 1] = new Student();
            studentCount--;
            RecordOperation("Deleted", deleted);
            Console.WriteLine("Student deleted successfully!");
        }
 
        static void DisplayAll()
        {
            if (studentCount == 0)
            {
                Console.WriteLine("No student records found.");
                return;
            }
 
            Console.WriteLine("STUDENT RECORDS");
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine("Student Number: " + students[i].StudentNumber);
                Console.WriteLine("Name: " + students[i].Name);
                Console.WriteLine("Program: " + students[i].Program);
                Console.WriteLine("Year Level: " + students[i].YearLevel);
                Console.WriteLine();
            }
        }
 
        // ---------- Stack operations ----------
        static void ViewHistory()
        {
            if (operationHistory.Count == 0)
            {
                Console.WriteLine("No recorded operations.");
                return;
            }
 
            // ToArray() returns the top of the stack first (newest -> oldest).
            // Loop backwards so the list reads oldest -> newest, like the sample output.
            Operation[] ops = operationHistory.ToArray();
            Console.WriteLine("OPERATION HISTORY");
            int number = 1;
            for (int i = ops.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(number + ". " + ops[i].Action + " " + ops[i].StudentName);
                number++;
            }
        }
 
        static void ViewLastOperation()
        {
            if (operationHistory.Count == 0)
            {
                Console.WriteLine("No recorded operations.");
                return;
            }
 
            Operation op = operationHistory.Peek(); // look at the top without removing it
            Console.WriteLine("Last Operation: " + op.Action + " " + op.StudentName);
        }
 
        static void RemoveLastOperation()
        {
            if (operationHistory.Count == 0)
            {
                Console.WriteLine("No recorded operations to remove.");
                return;
            }
 
            operationHistory.Pop(); // removes the most recent operation (LIFO)
            Console.WriteLine("Last operation removed successfully!");
        }
    }
}
 
