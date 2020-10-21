using System;

namespace Övningsprov
{
    class Program
    {
        static void Main(string[] args)
        {
            int points = 0;
            while (true)
            {
                Console.WriteLine("x*6=42 \nVad är X?");
                int x;
                bool succ = int.TryParse(Console.ReadLine(), out x);
                if (succ)
                {
                    if (x == 7)
                    {
                        System.Console.WriteLine("Korrekt!");
                        points++;
                        System.Console.WriteLine("Du har " + points + " poäng.");
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine($"Nej, {x}*6={x * 6}");
                        System.Console.WriteLine("Du har " + points + " poäng.");
                        break;
                    }
                }
                else
                {
                    System.Console.WriteLine("Skriv ett heltal");
                }
            }
        }
    }
}
