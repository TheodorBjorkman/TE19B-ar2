using System;
using TBA;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace projektuppgift3
{
    class Program
    {
        static int width = 6;
        static int height = 5;
        static bool startup = true;
        static int[,] map = new int[6, 5];
        static int[,] trueMap = new int[6, 5];
        static int[,] mapc = new int[6, 5];
        static int[,] trueMapc = new int[6, 5];
        static Random rng = new Random();
        static void Main()
        {
            if (startup)
            {
                Setup();
            }
            while (true)
            {
                int outputx = Menu("1 2 3 4 5 6".Split(" "));
                int outputy = Menu("1 2 3 4 5".Split(" "));
                System.Console.WriteLine(outputx + outputy);
            }
        }
        static int Menu(string[] items)
        {
            Selector selector = new Selector();
            foreach (string item in items)
            {
                selector.Add(item);
            }
            return selector.Run();
        }
        static void Setup()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    map[i, j] = 0;
                    trueMap[i,j] = 0;
                    mapc[i, j] = 0;
                    trueMapc[i, j] = 0;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                int boatx = rng.Next(0, 7);
                int boaty = rng.Next(0, 6);
                if (trueMap[boatx, boaty] == 0) trueMap[boatx, boaty] = 1;
                boatx = rng.Next(0, 7);
                boaty = rng.Next(0, 6);
                if (trueMapc[boatx, boaty] == 0) trueMapc[boatx, boaty] = 1;
            }
        }
        static void Shoot(int x, int y, bool player)
        {

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