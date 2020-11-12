using System;
using TBA;
using System.Collections.Generic;
using System.Threading;

namespace lmao
{
    class Program
    {
        static public string vinnare = "Ingen";
        static void Main()
        {
            int pTotal = 0;
            int cTotal = 0;
            int firstDraw = 0;
            int drawed;
            Random rnd = new Random();
            bool play = true;
            bool draw = true;
            bool first = true;
            bool loop = true;
            Console.WriteLine("Välkommen till 21:an!");
            while (loop)
            {
                Selector selector = new Selector();
                selector.Add("Kör");
                selector.Add("Senaste vinnare");
                selector.Add("Regler");
                selector.Add("Avsluta");
                int utput = selector.Run();
                selector.Clear();
                System.Console.WriteLine();
                switch (utput)
                {
                    case 0:
                        loop = false;
                        break;
                    case 1:
                        System.Console.WriteLine(vinnare);
                        break;
                    case 2:
                        Rules();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
            while (play)
            {
                while (draw)
                {
                    if (first)
                    {
                        firstDraw = rnd.Next(1, 11);
                        pTotal = pTotal + firstDraw;
                    }
                    drawed = rnd.Next(1, 11);
                    pTotal = pTotal + drawed;
                    if (pTotal > 21)
                    {
                        System.Console.WriteLine($"Du drog {drawed} och kom över 21 ({pTotal}). Du förlorade.");
                        vinnare = "Datorn";
                        Main();
                    }
                    if (first)
                    {
                        System.Console.WriteLine($"Du drog {drawed} och {firstDraw} du har {pTotal}. Dra ett till kort?");
                    }
                    else
                    {
                        System.Console.WriteLine($"Du drog {drawed} du har {pTotal}. Dra ett till kort?");
                    }
                    first = false;
                    Selector selector = new Selector();
                    selector.Add("Dra");
                    selector.Add("Stanna");
                    int output = selector.Run();
                    selector.Clear();
                    Console.WriteLine();
                    if (output == 1) draw = false;
                }
                draw = true;
                while (draw)
                {
                    drawed = rnd.Next(1, 11);
                    cTotal = cTotal + drawed;
                    System.Console.WriteLine($"Datorn drog {drawed} och har {cTotal}");
                    Thread.Sleep(2000);
                    if (cTotal > 21)
                    {
                        System.Console.WriteLine($"Datorn fick över 21 ({cTotal}). Du vann! \nSkriv ditt namn:");
                        vinnare = Console.ReadLine();
                        Main();
                    }
                    if (cTotal >= pTotal && cTotal <= 21)
                    {
                        System.Console.WriteLine($"Datorn fick {cTotal} vilket är lika mycket eller mer än dig ({pTotal}). Du förlorade.");
                        vinnare = "Datorn";
                        Main();
                    }
                }
            }
        }
        static void Rules()
        {
            System.Console.WriteLine("Du drar kort som har värden från 1 till 10. \nI början drar du två kort sedan får du välja om du vill dra mer. \nOm du kommer över totalt 21 poäng förlorar du. \nEfter du väljer att inte dra fler kort drar datorn kort, om datorn drar mer än dig men under 22 vinner datorn.");
            Selector selector = new Selector();
            selector.Add("Fortsätt");
            selector.Run();
            selector.Clear();
            System.Console.WriteLine();
            Main();
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
