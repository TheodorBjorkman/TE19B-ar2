using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using TBA;

namespace projektuppgift2
{
    class Program
    {
        static string defaultInfo = "1;0;Inga;gäster\n2;0;Inga;gäster\n3;0;Inga;gäster\n4;0;Inga;gäster\n5;0;Inga;gäster\n6;0;Inga;gäster\n7;0;Inga;gäster\n8;0;Inga;gäster";
        static string[] defaultInfoArray = defaultInfo.Split("\n");
        static string[] infoArray = defaultInfoArray;
        static bool start = true;
        static void Main()
        {
            System.Console.Clear();
            System.Console.WriteLine("Detta är Centralrestaurangens bordshanterare");
            Selector selector = new Selector();
            selector.Add("Skapa ny fil");
            selector.Add("Använd en existerande fil");
            selector.Add("Ta bort en fil");
            selector.Add("Använd senast använd fil");
            int output = selector.Run();
            selector.Clear();
            switch(output)
            {
                case 0:
                CreateFile();
                break;
                case 1:
                ChooseFile();
                break;
                case 2:
                DeleteFile();
                break;
                case 3:
                break;
            }
        }
        static void UpdateList()
        {
            File.WriteAllLines("tableInfo.txt", infoArray);
            Selection();
        }
        static void Selection()
        {
            if (!start) {
                System.Console.Clear();
            }
            start=false;
            Selector selector = new Selector();
            selector.Add("Visa alla bord");
            selector.Add("Lägg till/ändra bordsinformation");
            selector.Add("Markera att ett bord är tomt");
            selector.Add("Gå till filhanteraren");
            selector.Add("Avsluta");
            int input = selector.Run();
            selector.Clear();
            System.Console.WriteLine();
            switch (input)
            {
                case 0:
                    int total = 0;
                    foreach (string line in File.ReadAllLines("tableInfo.txt")) 
                    {
                        string[] raw = line.Split(";");
                        Console.Write($"Bord {raw[0]} - {raw[2]} {raw[3]}.");
                        if (int.Parse(raw[1]) > 0) Console.WriteLine($" Antal gäster: {raw[1]}"); else System.Console.WriteLine();
                        total += int.Parse(raw[1]);
                    }
                    Console.WriteLine("Totalt antal gäster: " + total);
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
                    Main();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
        static void Edit()
        {
            int nada = 0;
            bool succ = false;
            string[] input = new string[3];
            System.Console.Clear();
            System.Console.WriteLine("Välj bordet att ändra");
            Selector selector = new Selector();
            for (int x = 1; x <= 8; x++)
            {
                selector.Add($"Bord {x}");
            }
            int output = selector.Run();
            selector.Clear();
            while(true/*!succ && nada > 0*/) {
                System.Console.WriteLine();
                System.Console.WriteLine("Skriv förnamn efternamn och antal gäster med mellanrum");
                string[] inputTrue = Console.ReadLine().Split(" ");
                input = inputTrue;
                if(inputTrue.Length == 3) succ = int.TryParse(inputTrue[2], out nada);
                if(succ && nada > 0) break;
            }
            infoArray[output] = $"{(output + 1)};{input[2]};{input[0]};{input[1]}";
            UpdateList();
        }
        static void Empty()
        {
            System.Console.Clear();
            System.Console.WriteLine("Välj bordet att tömma");
            Selector selector = new Selector();
            for (int x = 1; x <= 8; x++)
            {
                selector.Add($"Bord {x}");
            }
            int output = selector.Run();
            selector.Clear();
            System.Console.WriteLine();
            infoArray[output] = defaultInfoArray[output];
            System.Console.WriteLine($"Bord {(output + 1)} har tömts");
            UpdateList();
        }
        static void Verify()
        {

        }
        static void ChooseFile()
        {
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
        }
        static void CreateFile()
        {
            int tableAmount;
            bool first = true;
            System.Console.WriteLine("Skriv hur många bord du vill ha");
            bool integer = false;
            while (!integer)
            {
                if (!first)
                {
                    System.Console.WriteLine("Fel sorts input");
                } else 
                {
                    first = false;
                }
                integer = int.TryParse(Console.ReadLine(), out tableAmount);
            }
            System.Console.WriteLine("Skriv namnet på filen");
            string fileName = Console.ReadLine();
            if (File.Exists(fileName + ".txt"))
            {
                Console.Clear();
                System.Console.WriteLine("Filen existerar redan. Vill du skriva över den?");
                Selector selector = new Selector();
                selector.Add("Ja");
                selector.Add("Nej");
                int input = selector.Run();
                selector.Clear();
                if (input == 0)
                {
                    
                }
            }
        }
        static void DeleteFile()
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