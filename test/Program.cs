using System;
using System.Threading;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            System.Console.Write("Write something: ");
            string test = Console.ReadLine();
            for(i = 0; i <= test.Length - 1; i++)
            {
                Thread.Sleep(50);
                Console.Write(test.Substring(i, 1));
            }
        }
    }
}
