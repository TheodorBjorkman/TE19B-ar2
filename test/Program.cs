using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                int nummer;
                bool succ = int.TryParse(input, out nummer);
                if (succ)
                {
                    System.Console.WriteLine(nummer);
                    break;
                }
                else
                {
                    System.Console.WriteLine("Skriv ett nummer");
                }
            }
        }
    }
}
