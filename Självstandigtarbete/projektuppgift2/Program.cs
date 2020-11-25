using System;
using System.IO;
using System.Collections.Generic;

namespace projektuppgift2
{
    class Program
    {
        static void Main()
        {
            int tableCount = 8;
            int[] guestCount = new int[tableCount];
            string[] guestNames = new string[tableCount];
            System.Console.WriteLine("Detta är Centralrestaurangens bordshanterare");
            if (File.Exists("tableInfo.txt"))
            {
                System.Console.WriteLine("Bordsinformation lästes in från fil");
            }
            else
            {
                File.WriteLines("tableInfo.txt", "Bord 1 - Inga gäster\nBord 2 - Inga gäster\nBord 3 - Inga gäster\nBord 4 - Inga gäster\nBord 5 - Inga gäster\nBord 6 - Inga gäster\nBord 7 - Namn: Inga gäster\nBord 8 - Inga gäster\nTotalt antal gäster: 0");
                System.Console.WriteLine("Fil med bordsinformation hittades ej, ny information skapades");
            }
        }
    }
}
