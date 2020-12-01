using System;
using System.Collections.Generic;

namespace ListaExempel
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> a = new List<string>();
            for (int i = 0; i < 4; i++) a.Add("a ");
            foreach (string aa in a)
            {
                System.Console.WriteLine(aa);
            }
        }
    }
}
