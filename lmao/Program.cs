﻿using System;
using TBA;
using System.Collections.Generic;
using System.Threading;

namespace lmao
{
    class Program
    {
        static void Main(string[] )
        {
            int pTotal = 0;
            Random rnd = new Random();
            bool play = true;
            bool draw = true;
            System.Console.WriteLine("Blackjack!");
            while (play)
            {
                while (draw)
                {
                    int drawed = rnd.Next(1, 11);
                    pTotal = pTotal + drawed;
                    System.Console.WriteLine($"Du drog {drawed} du har {pTotal}. Dra ett till kort?");
                    Selector selector = new Selector();
                    selector.Add("Dra");
                    selector.Add("Stanna");
                    int output = selector.Run();
                    selector.Clear();
                    Console.WriteLine();
                    switch (output)
                    {
                        case 0:
                            System.Console.WriteLine("Case 1");
                            break;
                        case 1:
                            System.Console.WriteLine("Case 2");
                            break;
                    }
                    Environment.Exit(0);
                }
            }
        }
    }
}
namespace TBA //Big brain kod från Fritiof. Har studerat tillräckligt för att förstå hur den fungerar, att skriva på egen hand skulle dock ta lång tid, mycket google och inte varit lika snyggt.
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
        static void Write(bool line, string write) //kopierade in från min egen kod. Kan nog göra den till public men jag orkar inte. Gör det också lättare att copy pasta hela mey systemet.
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
