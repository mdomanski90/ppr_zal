// See https://aka.ms/new-console-template for more information
using static System.Runtime.InteropServices.JavaScript.JSType;

Console.WriteLine("Hello, World!");
Console.ReadLine();

Display.DisplayEmployeeList();
Display.DisplaySelectionScreen();
var employees = Data.GetEmployees();
foreach (var employee in employees)
{
    Console.WriteLine($"ID: {employee.id}, Full Name: {employee.fullName}, Birth Date: {employee.birthDate}, Occupation: {employee.occupation}, Hourly Rate: {employee.hourlyRate}, Full Time Salary: {employee.fullTimeSallary}");
}
Console.ReadLine();