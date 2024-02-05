using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppr_zal_gr3_zaklad
{
    public class Money
    {
        public static bool IsTaxable(int id)
        {
            var employee = DataInput.GetEmployeeById(id);
            int age = employee.Age;
            if (age > 26)
            {
                return true;
            }
            return false;
        }

        public static void CalcSalary(Employee employee, int days, decimal bonus)
        {
            decimal SalaryB;
            if (employee.hourlyRate > 0)
            {

                decimal SalaryBW = employee.hourlyRate;
                
                if (days == 20)
                {
                    SalaryBW = employee.hourlyRate * days * 8m + bonus;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Przyznana premia: " + Math.Round(bonus, 2) + " zł");
                    Console.ResetColor();
                }
                else SalaryBW = employee.hourlyRate * days * 8m;
                SalaryB = SalaryBW;
            }
            else
            {
                decimal SalaryBOf = employee.fullTimeSallary;
                if (days == 20)
                {
                    SalaryBOf = employee.fullTimeSallary + bonus;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Przyznana premia: " + Math.Round(bonus,2) + " zł");
                    Console.ResetColor();
                }
                else SalaryBOf = employee.fullTimeSallary * 0.8m;
                SalaryB = SalaryBOf;
            }
            decimal SalaryN;
            decimal TaxRate = 0.18m;
            decimal TaxAmount = SalaryB * TaxRate;
            SalaryN = SalaryB - TaxAmount;

            Display.DisplaySalary(employee, SalaryN, SalaryB, TaxAmount);

        }

    }
}
