using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main()
        {
            TBA.Selector selector = new TBA.Selector();
            selector.Add("test");
            selector.Add("test2");
            selector.Add("test3");
            int output = selector.Run();
            selector.Clear();
            System.Console.WriteLine(output);
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

        public int Run()
        {
            string[] selectOptions = options.ToArray();
            int intialTop = Console.CursorTop;

            string printString = "\n";
            foreach (string option in selectOptions)
            {
                printString += "  " + option + "\n";
            }
            Console.WriteLine(printString);
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