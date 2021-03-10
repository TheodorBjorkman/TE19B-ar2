using System;

namespace Exempel_2
{
    class Program
    {
        static void Main()
        {
            while(true)
            {
                bool succ = false;
                int input = 0;
                System.Console.WriteLine("Välj ett alternativ");
                System.Console.WriteLine("1. Addera två tal");
                System.Console.WriteLine("2. Subtrahera två tal");
                System.Console.WriteLine("3. Multiplicera två tal");
                System.Console.WriteLine("4. Avsluta programmet");
                while(!succ)
                {
                    succ = int.TryParse(Console.ReadLine(), out input);
                }
                switch (input)
                {
                    case 1:
                        Console.WriteLine(Add(Request()));
                        break;
                    case 2:
                        Console.WriteLine(Subtract(Request()));
                        break;
                    case 3:
                        Console.WriteLine(Multiply(Request()));
                        break;
                    case 4:
                        System.Environment.Exit(0);
                        break;
                }
            }
        }

        static int[] Request()
        {
            bool succ = false;
            int[] input = new int[2];
            while(!succ)
            {
                bool test = false;
                string inputString = "";
                while(!test)
                {
                    int trash;
                    System.Console.WriteLine("Skriv två tal separerade med ett mellanslag");
                    inputString = Console.ReadLine();
                    if (inputString.Length > 2 && inputString.Contains(' ') && int.TryParse(inputString[0].ToString(), out trash) && int.TryParse(inputString[inputString.Length - 1].ToString(), out trash)) test = true;
                }
                string[] inputStringArray = inputString.Split(' ');
                succ = (int.TryParse(inputStringArray[0], out input[0]) && int.TryParse(inputStringArray[1], out input[1]) && inputStringArray.Length == 2);
            }
            return input;
        }

        static int Add(int[] input)
        {
            return (input[0] + input[1]);
        }

        static int Subtract(int[] input)
        {
            return (input[0] - input[1]);
        }

        static int Multiply(int[] input)
        {
            return (input[0] * input[1]);
        }
    }
}
