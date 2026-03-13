using System;

class Program
{
    static string[] names = new string[10];
    static int[] ids = new int[10];
    static double[] grades = new double[10];

    static int studentCount = 0;

    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== Student Management System ===");
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Calculate Average Grade");
            Console.WriteLine("4. Find Student by ID");
            Console.WriteLine("5. Update Student Grade");
            Console.WriteLine("6. Delete Student");
            Console.WriteLine("7. Display Statistics");
            Console.WriteLine("8. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;

                case "2":
                    ViewStudents();
                    break;

                case "3":
                    CalculateAverage();
                    break;

                case "4":
                    FindStudent();
                    break;

                case "5":
                    UpdateGrade();
                    break;

                case "6":
                    DeleteStudent();
                    break;

                case "7":
                    ShowStatistics();
                    break;

                case "8":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void AddStudent()
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter student ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter grade (0-100): ");
        double grade = double.Parse(Console.ReadLine());

        if (grade < 0 || grade > 100)
        {
            Console.WriteLine("Invalid grade.");
            return;
        }

        names[studentCount] = name;
        ids[studentCount] = id;
        grades[studentCount] = grade;

        studentCount++;

        Console.WriteLine("Student added successfully!");
    }

    static void ViewStudents()
    {
        Console.WriteLine("\nID    Name      Grade    Status");
        Console.WriteLine("----------------------------------");

        for (int i = 0; i < studentCount; i++)
        {
            string status = grades[i] >= 60 ? "Pass" : "Fail";

            Console.WriteLine($"{ids[i]}   {names[i]}   {grades[i]}   {status}");
        }
    }

    static void CalculateAverage()
    {
        if (studentCount == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        double total = 0;

        for (int i = 0; i < studentCount; i++)
        {
            total += grades[i];
        }

        double average = total / studentCount;

        Console.WriteLine($"Average Grade: {average:F2}");
    }

    static void FindStudent()
    {
        Console.Write("Enter student ID to search: ");
        int searchId = int.Parse(Console.ReadLine());

        for (int i = 0; i < studentCount; i++)
        {
            if (ids[i] == searchId)
            {
                Console.WriteLine($"Found: {names[i]} - Grade: {grades[i]}");
                return;
            }
        }

        Console.WriteLine("Student not found.");
    }

    static void UpdateGrade()
    {
        Console.Write("Enter student ID: ");
        int searchId = int.Parse(Console.ReadLine());

        for (int i = 0; i < studentCount; i++)
        {
            if (ids[i] == searchId)
            {
                Console.Write("Enter new grade: ");
                grades[i] = double.Parse(Console.ReadLine());

                Console.WriteLine("Grade updated.");
                return;
            }
        }

        Console.WriteLine("Student not found.");
    }

    static void DeleteStudent()
    {
        Console.Write("Enter student ID to delete: ");
        int searchId = int.Parse(Console.ReadLine());

        for (int i = 0; i < studentCount; i++)
        {
            if (ids[i] == searchId)
            {
                for (int j = i; j < studentCount - 1; j++)
                {
                    names[j] = names[j + 1];
                    ids[j] = ids[j + 1];
                    grades[j] = grades[j + 1];
                }

                studentCount--;

                Console.WriteLine("Student deleted.");
                return;
            }
        }

        Console.WriteLine("Student not found.");
    }

    static void ShowStatistics()
    {
        if (studentCount == 0)
        {
            Console.WriteLine("No students available.");
            return;
        }

        double highest = grades[0];
        double lowest = grades[0];
        int pass = 0;
        int fail = 0;

        for (int i = 0; i < studentCount; i++)
        {
            if (grades[i] > highest)
                highest = grades[i];

            if (grades[i] < lowest)
                lowest = grades[i];

            if (grades[i] >= 60)
                pass++;
            else
                fail++;
        }

        Console.WriteLine($"Highest Grade: {highest}");
        Console.WriteLine($"Lowest Grade: {lowest}");
        Console.WriteLine($"Passing Students: {pass}");
        Console.WriteLine($"Failing Students: {fail}");
    }
}
