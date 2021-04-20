using System;

namespace _6._10
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(TryInt());
        }
        static bool TryInt()
        {
            int a = 0;
            System.Console.WriteLine("Enter input");
            return int.TryParse(Console.ReadLine().Trim(), out a);
        }
    }
}
