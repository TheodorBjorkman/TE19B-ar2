using System;

namespace a
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string test = Console.ReadLine();
            int key;
            bool succ = int.TryParse(test, out key);
            string output = "";
            if (succ)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    char conv = input[i];
                    int ascii = (int)conv;
                    ascii + key;
                    conv = (int)ascii;
                    output = output + conv;
                }
            }
            else
            {
                System.Console.WriteLine("Write word then number");
            }
            Console.WriteLine(output);
        }
    }
}
