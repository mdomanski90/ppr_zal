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
            Console.WriteLine("WYBIERZ OPCJĘ:");
            Console.WriteLine("1 => LISTA WSZYSTKICH PRACOWNIKÓW");
            Console.WriteLine("2 => WYLICZ PENSJĘ PRACOWNIKA");
            Console.WriteLine("3 => ZAKOŃCZ PROGRAM");
            Console.WriteLine("WYBIERZ 1, 2 LUB 3:");
        }

        public static void DisplayEmployeeList()
        {
            Console.Clear();
            Console.WriteLine("Lista pracowników");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("ID | IMIĘ I NAZWISKO | DATA UR.| STANOWISKO");
            Console.WriteLine("---------------------------------------------------");

            var employees = DataInput.GetEmployees();
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.id} | {employee.fullName} | {employee.birthDate.ToShortDateString()} | {employee.occupation}");
                Console.WriteLine();
            }
        }
        public static void DisplayEmployeeDetails()
        {
            Console.Clear();
            Console.WriteLine("PROSZĘ PODAĆ ID PRACOWNIKA DLA KTÓREGO ZOSTANIE WYLICZONE WYNAGRODZENIE:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("WYLICZANIE WYNAGRODZENIA PRACOWNIKA");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("DANE PRACOWNIKA");
            Console.WriteLine("---------------------------------------------------");

            var employees = DataInput.GetEmployees();
            var employee = employees.FirstOrDefault(e => e.id == id);
            if (employee != null)
            {
                Console.WriteLine($"IMIE I NAZWISKO: {employee.fullName}");

                var dOfB = employee.birthDate;
                int age = DateTime.Now.Year - dOfB.Year;

                Console.WriteLine($"WIEK: {age}");
                Console.WriteLine($"STANOWISKO: {employee.occupation}");
                if (employee.hourlyRate > 0)
                {
                    Console.WriteLine($"STAWKA GODZINOWA: {employee.hourlyRate} zł\\h");
                }
                if (employee.fullTimeSallary > 0)
                {
                    Console.WriteLine($"STAŁA PENSJA: {employee.fullTimeSallary} zł");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Pracownik o Id {id} nie istnieje.");
            }
            Console.WriteLine("PROSZĘ PODAĆ ILOŚĆ PRZEPRACOWANYCH DNI PRZEZ PRACOWNIKA (MAX.20):");
            int days = Convert.ToInt32(Console.ReadLine());
            if (days > 0 && days <= 20)
            {
                Console.Clear();
                Console.WriteLine("PROSZĘ PODAĆ KWOTĘ PREMII DLA PRACOWNIKA:");
                int bonus = Convert.ToInt32(Console.ReadLine());
                if (employee.hourlyRate > 0)
                {

                    decimal SalaryW = employee.hourlyRate;
                    if (days == 20)
                    {
                        SalaryW = employee.hourlyRate * days * 8m + bonus;
                    }
                    else SalaryW = employee.hourlyRate * days * 8m;

                    var SalaryWr = Math.Round(SalaryW, 2);

                    Console.WriteLine("Blabla WYNAGRODZENIE PRACOWNIKA BRUTTO: " + SalaryWr + " zł");
                }
                else
                {
                    decimal SalaryOf = employee.fullTimeSallary;
                    if (days == 20)
                    {
                        SalaryOf = employee.fullTimeSallary + bonus;
                    }
                    else SalaryOf = employee.fullTimeSallary * 0.8m;
                    var SalaryOfr = Math.Round(SalaryOf Of, 2)
                    Console.WriteLine("WYNAGRODZENIE PRACOWNIKA BRUTTO: " + SalaryOfr + " zł");
                }
            }
            else
            {
                Console.WriteLine("Pracownik musiał przepracować minimum 1 dzień, i nie mógł przepracować więcej niż 20 dni");
            }
            Console.WriteLine();

        }
    }
}
