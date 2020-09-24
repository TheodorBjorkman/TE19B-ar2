using System;

namespace projekt1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string input = Console.ReadLine();
            input = input.ToLower();
            if(input == "outhouse") {


            } else if(input == "cave") {


            }
        }

        static void Write(bool line, string input) {
            if(line == false) {
                Console.Write(input);
            } else {
                System.Console.WriteLine(input);
            }
        }
    }
}
