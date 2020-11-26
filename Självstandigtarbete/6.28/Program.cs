using System;

namespace _6._28
{
    class Program
    {
        static void Main(string[] args)
        {
            RitaKvadrat(2, 'A');
            RitaKvadrat(3, 'B', 2);
        }
        static void RitaKvadrat(int size, char character)
        {
            string kvadrat = "";
            for (int i = 0; i < size; i++)
            {
                kvadrat += character;
            }
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(kvadrat);
            }
        }
        static void RitaKvadrat(int size, char character, int space)
        {
            string kvadrat = "";
            for (int i = 0; i < size; i++)
            {
                kvadrat += character;
                for (int j = 0; j < space; j++)
                {
                    kvadrat += "    ";
                }
            }
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(kvadrat);
                for (int j = 0; j < space; j++)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
