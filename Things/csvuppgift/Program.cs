using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using TBA;

namespace Countries
{
    class Program
    {
        static void Main(string[] args)
        {
            // Presentera programmet
            Console.Clear();
            System.Console.WriteLine("Sök efter länder");

            // Läs in alla rader från textfilen countries.csv
            string[] countries = File.ReadAllLines("countries.csv");
            bool cont = true;

            // Programloopen, avslutas med return
            while (cont)
            {
                Selector selector = new Selector();
                selector.Add("Sök");
                selector.Add("Avsluta");
                int input = selector.Run();
                selector.Clear();
                System.Console.WriteLine();
                string sInput;
                Console.Clear();
                if (input == 0)
                {
                    System.Console.WriteLine("Skriv en sökterm");
                    sInput = Console.ReadLine().ToLower().Trim();
                    foreach(string line in countries)
                    {
                        string lineTrue = line.Replace("\"", "");
                        if (line.Contains(sInput)) 
                        {
                            string[] output = lineTrue.Split(",");
                            System.Console.WriteLine($"{output[0]} {output[1]}: {output[3]}");
                        }
                    }
                    System.Console.WriteLine("Tryck på en knapp för att fortsätta");
                    Console.ReadLine();
                    Console.Clear();
                } else cont = false;
            }
        }
    }
}
namespace TBA
{
    class Selector
    {
        int cursorPos = 0;
        List<string> options;

        public Selector()
        {
            options = new List<string>();
        }

        public void Clear()
        {
            options = new List<string>();
        }

        public void Add(string item)
        {
            if (!options.Contains(item))
            {
                options.Add(item);
            }
        }

        public void AddRange(string[] items)
        {
            options.AddRange(items);
        }

        private void moveCursorPos(int amount, int min, int max)
        {
            cursorPos = cursorPos + amount;
            if (cursorPos >= max)
            {
                cursorPos = max - 1;
            }
            if (cursorPos < min)
            {
                cursorPos = min;
            }
        }

        void drawAtPos(string text, int pos)
        {
            Console.SetCursorPosition(0, pos);
            Console.Write(text);
        }
        static void Write(bool line, string write)
        {

            if (line == false)
            {
                int i;
                for (i = 0; i <= write.Length - 1; i++)
                {
                    Thread.Sleep(20);
                    Console.Write(write.Substring(i, 1));
                }

            }
            else
            {
                int i;
                for (i = 0; i <= write.Length - 1; i++)
                {
                    Thread.Sleep(20);
                    Console.Write(write.Substring(i, 1));
                }
                System.Console.WriteLine();

            }
        }

        public int Run()
        {
            string[] selectOptions = options.ToArray();
            int intialTop = Console.CursorTop;

            string printString = "\n";
            foreach (string option in selectOptions)
            {
                printString += "  " + option + "\n";
            }
            Write(true, printString);
            drawAtPos(">", intialTop + cursorPos + 1);
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        drawAtPos(" ", intialTop + cursorPos + 1);
                        moveCursorPos(1, 0, selectOptions.Length);
                        drawAtPos(">", intialTop + cursorPos + 1);
                        break;
                    case ConsoleKey.UpArrow:
                        drawAtPos(" ", intialTop + cursorPos + 1);
                        moveCursorPos(-1, 0, selectOptions.Length);
                        drawAtPos(">", intialTop + cursorPos + 1);
                        break;
                    case ConsoleKey.Enter:
                        int newCursor = intialTop;
                        for (int i = 0; i <= selectOptions.Length; i++)
                        {
                            newCursor++;
                            Console.SetCursorPosition(0, newCursor);
                            Console.Write(new string(' ', Console.WindowWidth));
                        }
                        Console.SetCursorPosition(0, intialTop);
                        return cursorPos;
                }
            }
        }
    }
}