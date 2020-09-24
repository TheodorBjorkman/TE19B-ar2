using System;

namespace projekt1
{
    class Program
    {
        static void Main(string[] args)
        {
            Write(false, "You are standing in front of a cave entrance located at the foot of a mountain. There is an outhouse a few meters to the left of the entrance. Where do you go? ");

            string input = Console.ReadLine();

            input = input.ToLower();

            if(input == "outhouse") {

                Write(true, "Outhouse");

            } else if(input == "cave") {

                Write(true, "Cave");

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
