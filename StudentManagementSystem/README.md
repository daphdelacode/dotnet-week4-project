# Student Management System

**Author:** [Your Name]

## Description
This is a console-based Student Management System built in C#. It allows users to manage student records including adding, viewing, updating, and deleting students, as well as calculating grades and displaying statistics.

## How to Run
1. Ensure you have .NET installed.
2. Navigate to the project directory.
3. Run `dotnet run` in the terminal.

## Features
- Add new students with name, ID, and grade (with validation for positive ID, unique ID, and grade 0-100)
- View all students with pass/fail status and enrollment status in a formatted table
- Calculate average grade
- Find students by ID
- Update student grades (with validation)
- Delete students
- Display statistics (highest/lowest grade, pass/fail counts, enrolled count)

## Example Usage
```
=== Student Management System ===
1. Add New Student
...
Enter your choice: 1
Enter student name: Alice Johnson
Enter student ID: 101
Enter grade (0-100): 85.5
Student added successfully!
```

## Concepts Demonstrated
- Variables and data types (string, int, double, bool)
- Arrays for data storage
- Loops (while, for) and conditionals (if-else)
- Switch statements for menu handling
- Input validation and error handling with try-catch (TryParse)
- Arithmetic operators (+, /) and relational operators (>, <, >=)
- Logical operators (&&, ||) in statistics
- Assignment operators (=) for updates

## Challenges Faced
- Implementing input validation to prevent crashes on invalid inputs.
- Managing array shifting for deletion without losing data.
- Ensuring proper formatting for table display.