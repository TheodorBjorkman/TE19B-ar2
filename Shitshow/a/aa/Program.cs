using System;

namespace aa
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string output = "";
            char test;
            char test2;
            int conv;
            for(int i = 0; i == input.Length; i++)
            {
                test = input[i];
                conv = (int)test;
                conv++;
                test2 = (char)conv;
                output = output + test2;
            System.Console.WriteLine(output);
            }
        }
    }
}
