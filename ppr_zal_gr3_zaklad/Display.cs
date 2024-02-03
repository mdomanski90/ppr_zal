using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
            Console.WriteLine("wwaa");
        }
    }
}
