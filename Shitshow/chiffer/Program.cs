using System;

namespace chiffer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                int m;
                bool succ = int.TryParse(Console.ReadLine(), out m);
                string output = "";
                if (succ)
                {
                    for (int i = 0; i < input.Length; i++)
                    {
                        char c = input[i];
                        int conv = (int)c;
                        conv = conv + m;
                        c = (char)conv;
                        output = output + c;
                    }
                    System.Console.WriteLine(output);
                }
                else
                {
                    System.Console.WriteLine("no");
                }

            }
        }
    }
}
