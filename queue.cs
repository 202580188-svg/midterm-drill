using System;
using System.Collections.Generic;
 
namespace Problem3_Queue
{
    struct StudentRequest
    {
        public string StudentNumber;
        public string StudentName;
        public string RequestType;
    }
 
    class Program
    {
        static Queue<StudentRequest> requestQueue = new Queue<StudentRequest>();
 
        static void Main()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("========================================");
                Console.WriteLine("STUDENT REQUEST QUEUE");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add Request");
                Console.WriteLine("2. View Pending Requests");
                Console.WriteLine("3. Process Request");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();
 
                switch (choice)
                {
                    case "1": AddRequest(); break;
                    case "2": ViewRequests(); break;
                    case "3": ProcessRequest(); break;
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
 
        static void AddRequest()
        {
            StudentRequest r = new StudentRequest();
            Console.Write("Enter Student Number: ");
            r.StudentNumber = Console.ReadLine().Trim();
            Console.Write("Enter Student Name: ");
            r.StudentName = Console.ReadLine();
            Console.Write("Enter Request Type: ");
            r.RequestType = Console.ReadLine();
 
            requestQueue.Enqueue(r); // goes to the back of the line
            Console.WriteLine("Request added successfully!");
        }
 
        static void ViewRequests()
        {
            if (requestQueue.Count == 0)
            {
                Console.WriteLine("No pending requests.");
                return;
            }
 
            Console.WriteLine("REQUEST QUEUE");
            int number = 1;
            // Enumerating a Queue goes from first (front) to last (back)
            foreach (StudentRequest r in requestQueue)
            {
                Console.WriteLine(number + ". " + r.StudentName + " - " + r.RequestType);
                number++;
            }
        }
 
        static void ProcessRequest()
        {
            if (requestQueue.Count == 0)
            {
                Console.WriteLine("No pending requests to process.");
                return;
            }
 
            StudentRequest r = requestQueue.Dequeue(); // removes the oldest request (FIFO)
            Console.WriteLine("Processing Request: " + r.StudentName + " - " + r.RequestType);
            Console.WriteLine("Request processed successfully!");
        }
    }
}
 
