using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ppr_zal_gr3_zaklad
{
    public static class Display
    {
        public static void DisplaySelectionScreen()
        {
            Console.WriteLine(" WYBIERZ OPCJĘ:");
            Console.WriteLine(" 1 => LISTA WSZYSTKICH PRACOWNIKÓW");
            Console.WriteLine(" 2 => WYLICZ PENSJĘ PRACOWNIKA");
            Console.WriteLine(" 3 => ZAKOŃCZ PROGRAM");
            Console.WriteLine(" WYBIERZ 1, 2 LUB 3:");
            Console.ReadLine();
        }

        public static void DisplayEmployeeList()
        {
            Console.Clear();
            Console.WriteLine("Lista pracowników");
            Console.WriteLine();
            Console.WriteLine("Id   |Imię i nazwisko     |Data urodzenia      |Stanowisko           |zł/h           |pensja stała");
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            
            var employees = DataInput.GetEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.id}, Full Name: {employee.fullName}, Birth Date: {employee.birthDate}, Occupation: {employee.occupation}, Hourly Rate: {employee.hourlyRate}, Full Time Salary: {employee.fullTimeSallary}");
            }
            Console.ReadLine();
        }
    }
}
