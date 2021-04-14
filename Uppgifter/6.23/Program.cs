using System;

namespace _6._23
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine(EverySecondWordCapitalized(input));
                Console.WriteLine(GörFörstaBokstavenStor(input));
            }
        }
        static string EverySecondWordCapitalized(string input)
        {
            string[] inputArray = input.Split(' ');
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    inputArray[i] = inputArray[i].ToUpper();
                }
                else
                {
                    inputArray[i] = inputArray[i].ToLower();
                }
            }
            return String.Join(' ', inputArray);
        }
        static string GörFörstaBokstavenStor(string input)
        {
            string[] inputArray = input.Split(' ');
            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = inputArray[i].Substring(0, 1).ToUpper() + inputArray[i].Substring(1);
            }
            return String.Join(' ', inputArray);
        }
    }
}
