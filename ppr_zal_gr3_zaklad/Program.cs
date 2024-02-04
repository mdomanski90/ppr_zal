// See https://aka.ms/new-console-template for more information
using ppr_zal_gr3_zaklad;
using System.Threading.Channels;
using static System.Runtime.InteropServices.JavaScript.JSType;

    do
    {
        Display.DisplaySelectionScreen();
        var userInput = Console.ReadLine();

        if (userInput == "1")
        {
            Display.DisplayEmployeeList();
        }
        else if (userInput == "2")
        {
            Display.DisplayEmployeeDetails();
        }
        else if (userInput == "3")
        {
            Console.WriteLine("KONIEC PROGRAMU");
            Console.WriteLine("wciśnij dowolny klawisz...");
            break;
        }
        
    }
    while (true);
