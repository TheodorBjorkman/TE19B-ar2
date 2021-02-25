using System;

namespace _6._1
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                System.Console.WriteLine("Skriv ett tal");
                int a = 0;
                bool test = false;
                while (!test) 
                {
                    test = int.TryParse(Console.ReadLine(), out a);
                }
                RitaRätvinkligTriangel(a);
            }
        }
        static void RitaRätvinkligTriangel(int sidlängd)
        {
            for (int i = 0; i < sidlängd; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("*");
                }
                System.Console.WriteLine();
            }
        }
    }
}
