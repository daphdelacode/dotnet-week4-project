using System;

class Program
{
    // Arrays to store student data
    static string[] names = new string[10];
    static int[] ids = new int[10];
    static double[] grades = new double[10];
    static bool[] enrolled = new bool[10]; // Enrollment status

    static int studentCount = 0;

    static void Main()
    {
        bool running = true;

        // Main menu loop using while loop and switch statement
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

        // Validate and parse ID
        Console.Write("Enter student ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
        {
            Console.WriteLine("Invalid ID. Must be a positive integer.");
            return;
        }

        // Check for duplicate ID
        for (int i = 0; i < studentCount; i++)
        {
            if (ids[i] == id)
            {
                Console.WriteLine("Student ID already exists.");
                return;
            }
        }

        // Validate and parse grade
        Console.Write("Enter grade (0-100): ");
        if (!double.TryParse(Console.ReadLine(), out double grade) || grade < 0 || grade > 100)
        {
            Console.WriteLine("Invalid grade. Must be between 0 and 100.");
            return;
        }

        // Add student
        names[studentCount] = name;
        ids[studentCount] = id;
        grades[studentCount] = grade;
        enrolled[studentCount] = true; // Mark as enrolled

        studentCount++;

        Console.WriteLine("Student added successfully!");
    }

    static void ViewStudents()
    {
        Console.WriteLine("\nID      Name                Grade     Status    Enrolled");
        Console.WriteLine("-------------------------------------------------------");

        for (int i = 0; i < studentCount; i++)
        {
            string status = grades[i] >= 60 ? "Pass" : "Fail";
            string enrollStatus = enrolled[i] ? "Yes" : "No";

            Console.WriteLine($"{ids[i],-6} {names[i],-20} {grades[i],-8:F1} {status,-6} {enrollStatus}");
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

        // Use a loop to sum all grades (arithmetic operators)
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
        if (!int.TryParse(Console.ReadLine(), out int searchId))
        {
            Console.WriteLine("Invalid ID. Please enter a number.");
            return;
        }

        for (int i = 0; i < studentCount; i++)
        {
            if (ids[i] == searchId)
            {
                Console.WriteLine($"Found: {names[i]} - Grade: {grades[i]} - Enrolled: {enrolled[i]}");
                return;
            }
        }

        Console.WriteLine("Student not found.");
    }

    static void UpdateGrade()
    {
        Console.Write("Enter student ID: ");
        if (!int.TryParse(Console.ReadLine(), out int searchId))
        {
            Console.WriteLine("Invalid ID. Please enter a number.");
            return;
        }

        for (int i = 0; i < studentCount; i++)
        {
            if (ids[i] == searchId)
            {
                Console.Write("Enter new grade (0-100): ");
                if (!double.TryParse(Console.ReadLine(), out double newGrade) || newGrade < 0 || newGrade > 100)
                {
                    Console.WriteLine("Invalid grade. Must be between 0 and 100.");
                    return;
                }

                grades[i] = newGrade;
                Console.WriteLine("Grade updated.");
                return;
            }
        }

        Console.WriteLine("Student not found.");
    }

    static void DeleteStudent()
    {
        Console.Write("Enter student ID to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int searchId))
        {
            Console.WriteLine("Invalid ID. Please enter a number.");
            return;
        }

        for (int i = 0; i < studentCount; i++)
        {
            if (ids[i] == searchId)
            {
                // Shift arrays to remove the student
                for (int j = i; j < studentCount - 1; j++)
                {
                    names[j] = names[j + 1];
                    ids[j] = ids[j + 1];
                    grades[j] = grades[j + 1];
                    enrolled[j] = enrolled[j + 1];
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
        int enrolledCount = 0;

        // Use relational operators (>, <) and logical operators (&&, ||) to calculate stats
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

            if (enrolled[i])
                enrolledCount++;
        }

        Console.WriteLine($"Highest Grade: {highest:F1}");
        Console.WriteLine($"Lowest Grade: {lowest:F1}");
        Console.WriteLine($"Passing Students: {pass}");
        Console.WriteLine($"Failing Students: {fail}");
        Console.WriteLine($"Enrolled Students: {enrolledCount}");
    }
}