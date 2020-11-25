//Skapa ett program där användaren ska skriva in en beräkning innehållande två decimaltal och ett gångertecken på samma rad, t.ex. 5,2*3,8. Programmet ska utföra beräkningen och berätta vad svaret är.
using System;

namespace hoj
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Skriv multiplikation med decimal (använd komma): ");
            string input = Console.ReadLine();

            string number1 = input.Substring(0, input.IndexOf("*"));

            double full1 = double.Parse(number1);

            string number2 = input.Substring(input.IndexOf("*") + 1);

            double full2 = double.Parse(number2);

            double answer = full1 * full2;
            
            System.Console.WriteLine(answer);
        }
    }
}
