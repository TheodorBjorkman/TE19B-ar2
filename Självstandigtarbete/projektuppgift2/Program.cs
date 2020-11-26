using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using TBA;

namespace projektuppgift2
{
    class Program
    {
        static string defaultInfo = "Bord 1 - Inga gäster\nBord 2 - Inga gäster\nBord 3 - Inga gäster\nBord 4 - Inga gäster\nBord 5 - Inga gäster\nBord 6 - Inga gäster\nBord 7 - Inga gäster\nBord 8 - Inga gäster\nTotalt antal gäster: 0";
        static string[] defaultInfoArray = defaultInfo.Split("\n");
        static string[] infoArray = defaultInfoArray;
        static void Main()
        {
            System.Console.WriteLine("Detta är Centralrestaurangens bordshanterare");
            if (File.Exists("tableInfo.txt"))
            {
                System.Console.WriteLine("Bordsinformation lästes in från fil");
                infoArray = File.ReadAllLines("tableInfo.txt");
            }
            else
            {
                File.WriteAllLines("tableInfo.txt", defaultInfoArray);
                System.Console.WriteLine("Fil med bordsinformation hittades ej, ny information skapades");
            }
            Selection();
        }
        static void UpdateList()
        {
            File.WriteAllLines("tableInfo.txt", infoArray);
            Selection();
        }
        static void Selection()
        {
            Selector selector = new Selector();
            selector.Add("Visa alla bord");
            selector.Add("Lägg till/ändra bordsinformation");
            selector.Add("Markera att ett bord är tomt");
            selector.Add("Avsluta");
            int input = selector.Run();
            selector.Clear();
            System.Console.WriteLine();
            switch (input)
            {
                case 0:
                    foreach (string line in File.ReadAllLines("tableInfo.txt")) System.Console.WriteLine(line);
                    selector.Add("Fortsätt");
                    int lol = selector.Run();
                    selector.Clear();
                    System.Console.WriteLine();
                    Selection();
                    break;
                case 1:
                    Edit();
                    break;
                case 2:
                    Empty();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }
        static void Edit()
        {
            System.Console.WriteLine("Välj bordet att ändra");
            Selector selector = new Selector();
            selector.Add("Bord 1");
            selector.Add("Bord 2");
            selector.Add("Bord 3");
            selector.Add("Bord 4");
            selector.Add("Bord 5");
            selector.Add("Bord 6");
            selector.Add("Bord 7");
            selector.Add("Bord 8");
            int output = selector.Run();
            selector.Clear();
            System.Console.WriteLine();
            System.Console.WriteLine("Skriv förnamn efternamn och antal gäster med mellanrum");
            string[] input = Console.ReadLine().Split(" ");
            infoArray[output] = $"Bord {(output + 1)} - {input[0]} {input[1]}, antal gäster: {input[2]}";
            UpdateList();
        }
        static void Empty()
        {
            System.Console.WriteLine("Välj bordet att tömma");
            Selector selector = new Selector();
            selector.Add("Bord 1");
            selector.Add("Bord 2");
            selector.Add("Bord 3");
            selector.Add("Bord 4");
            selector.Add("Bord 5");
            selector.Add("Bord 6");
            selector.Add("Bord 7");
            selector.Add("Bord 8");
            int output = selector.Run();
            selector.Clear();
            System.Console.WriteLine();
            infoArray[output] = defaultInfoArray[output];
            System.Console.WriteLine($"Bord {(output + 1)} har tömts");
            UpdateList();
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