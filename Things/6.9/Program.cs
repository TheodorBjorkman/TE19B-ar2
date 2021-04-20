using System;

namespace _6._9
{
    class Program
    {
        static void Main()
        {
            System.Console.WriteLine(ReadDouble());
        }

        static double ReadDouble()
        {
            double a = 0;
            System.Console.WriteLine("Input a number");
            while (!double.TryParse(Console.ReadLine(), out a))
            {
                System.Console.WriteLine("Input a number (decimals are seperated by ',')");
            }
            return a;
        }
    }
}
