using System;

namespace Test
{
    class Program
    {
        static void Main()
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            for (x = x; x >= y; x = x - 1)
            {
                lmao();
            }
        }

        static void lmao()
        {
            System.Console.WriteLine("XD");
        }
    }
}
