using System;

namespace Exempel_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            int age;
            float height;
            string message = "";

            Console.Write("Vad heter du? ");
            name = Console.ReadLine();

            Console.Write("Hur gammal är du? ");
            age = int.Parse(Console.ReadLine());

            Console.Write("Hur lång är du (meter)? ");
            height = float.Parse(Console.ReadLine());

            message = "Hej, " + name + "!" + " Du är " + age + " år gammal och " + height + " lång.";

            Console.WriteLine(message);
        }
    }
}
