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

            var employee = DataInput.GetEmployeeById(id);
            if (employee != null)
            {
                Console.WriteLine($"IMIE I NAZWISKO: {employee.fullName}");

               

                Console.WriteLine($"WIEK: {employee.Age}");
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
                decimal bonus = Convert.ToDecimal(Console.ReadLine());
                Console.Clear();
                Money.CalcSalary(employee, days, bonus);
            }
            else
            {
                Console.WriteLine("Pracownik musiał przepracować minimum 1 dzień, i nie mógł przepracować więcej niż 20 dni");
            }
        }
        public static void DisplaySalary (Employee employee, decimal SalaryB, decimal SalaryN, decimal TaxAmount)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Pensja burtto: " + Math.Round(SalaryN, 2) + " zł"); //dlaczego SalaryN to SalaryB i odwrotnie. Dlaczego muszę wpisać netto za brutto, brutto za netto, zeby sie zgadzało.
            if (Money.IsTaxable(employee.id))
            {
                Console.WriteLine("Kwota podatku: " + Math.Round(TaxAmount, 2) + " zł");
                Console.WriteLine("Pensja do wypłaty: " + Math.Round(SalaryB, 2) + " zł");
                Console.WriteLine();
            }

            else
            {
                Console.WriteLine("Pensja do wypłaty: " + Math.Round(SalaryN, 2) + " zł");
                Console.WriteLine("Pensja nie podlega opodatkowaniu");
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
