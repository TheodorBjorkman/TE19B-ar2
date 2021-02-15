using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using TBA;

namespace projektuppgift2
{
    class Program
    {
        static int tables = 8;
        static string currentFile = "";
        static List<string> content = new List<string>();
        static string defaultInfo = ";0;Inga;Gäster;0";
        static void Main()
        {
            if (File.Exists("lastUsed.csv"))
            {
                currentFile = File.ReadAllLines("lastUsed.csv")[0].Trim();
            }
            else
            {
                File.Create("lastUsed.csv").Close();
                File.WriteAllText("lastUsed.csv", "null");
            }
            while (true)
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
                switch (output)
                {
                    case 0:
                        CreateFile();
                        break;
                    case 1:
                        if (ChooseFile()) Selection();
                        break;
                    case 2:
                        DeleteFile();
                        break;
                    case 3:
                        if (File.Exists(currentFile))
                        {
                            Verify();
                            Selection();
                        }
                        else
                        {
                            Console.Clear();
                            System.Console.WriteLine("Filen existerar inte, välj en annan fil. Tryck på en knapp för att fortsätta");
                            Console.ReadLine();
                        }
                        break;
                }
            }
        }
        static void Selection()
        {
            System.Console.Clear();
            tables = File.ReadAllLines(currentFile).Length;
            while (true)
            {
                Selector selector = new Selector();
                selector.Add("Visa alla bord");
                selector.Add("Lägg till/ändra bordsinformation");
                selector.Add("Markera att ett bord är tomt");
                selector.Add("Gå till filhanteraren");
                selector.Add("Ändra nota");
                selector.Add("Avsluta");
                int input = selector.Run();
                selector.Clear();
                System.Console.WriteLine();
                switch (input)
                {
                    case 0:
                        int total = 0;
                        foreach (string line in File.ReadAllLines(currentFile))
                        {
                            string[] raw = line.Split(";");
                            Console.Write($"Bord {raw[0]} - {raw[2]} {raw[3]}.");
                            if (int.Parse(raw[1]) > 0 && int.Parse(raw[4]) > 0) Console.WriteLine($" Antal gäster: {raw[1]}. Nota: {raw[4]}");
                            else if (int.Parse(raw[1]) > 0) Console.WriteLine($" Antal gäster: {raw[1]}.");
                            else System.Console.WriteLine();
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
                        Bill();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        static void Bill()
        {
            System.Console.Clear();
            System.Console.WriteLine("Välj bordet att ändra notan på");
            Selector selector = new Selector();
            for (int x = 0; x < tables; x++)
            {
                selector.Add($"Bord {x + 1}");
            }
            int output = selector.Run();
            selector.Clear();
            int input;
            while (true)
            {
                System.Console.WriteLine("Skriv ny nota");
                if (int.TryParse(Console.ReadLine(), out input))
                {
                    if (input > 0)
                    {
                        break;
                    }
                }
            }
            string[] contentArray = content[output].Split(";");
            contentArray[4] = $"{input}";
            string temp = string.Join(";", contentArray);
            content[output] = temp;
            Console.Clear();
            File.WriteAllLines(currentFile, content);
        }
        static void Edit()
        {
            int nada = 0;
            bool succ = false;
            string[] input = new string[3];
            System.Console.Clear();
            System.Console.WriteLine("Välj bordet att ändra");
            Selector selector = new Selector();
            for (int x = 0; x < tables; x++)
            {
                selector.Add($"Bord {x + 1}");
            }
            int output = selector.Run();
            selector.Clear();
            while (true/*!succ && nada > 0*/)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Skriv förnamn efternamn och antal gäster med mellanrum");
                string[] inputTrue = Console.ReadLine().Split(" ");
                input = inputTrue;
                if (inputTrue.Length == 3) succ = int.TryParse(inputTrue[2], out nada);
                if (succ && nada > 0) break;
            }
            string[] contentArray = content[output].Split(";");
            content[output] = $"{(output + 1)};{input[2]};{input[0]};{input[1]};{contentArray[4]}";
            File.WriteAllLines(currentFile, content);
            Console.Clear();
        }
        static void Empty()
        {
            System.Console.Clear();
            System.Console.WriteLine("Välj bordet att tömma");
            Selector selector = new Selector();
            for (int x = 0; x < tables; x++)
            {
                selector.Add($"Bord {x + 1}");
            }
            int output = selector.Run();
            selector.Clear();
            System.Console.WriteLine();
            content[output] = $"{output}{defaultInfo}";
            System.Console.WriteLine($"Bord {(output + 1)} har tömts");
            File.WriteAllLines(currentFile, content);
        }
        static bool Verify()
        {
            bool test = true;
            int empty;
            content.Clear();
            content.AddRange(File.ReadAllLines(currentFile));
            foreach (string item in content)
            {
                string[] items = item.Split(";");
                for (int i = 0; i < items.Length; i++)
                {
                    if (i != 2 && i != 3 && items.Length != 5)
                    {
                        if (!int.TryParse(items[i], out empty)) test = false;
                    }
                }
            }
            return test;
        }
        static bool ChooseFile()
        {
            while (true)
            {
                Console.Clear();
                string[] fileList = Directory.GetFiles($"{Directory.GetCurrentDirectory()}", "*.txt");
                if (fileList.Length > 0)
                {
                    System.Console.WriteLine("Välj filen du vill använda:");
                    Selector selector = new Selector();
                    foreach (string item in fileList)
                    {
                        selector.Add(item);
                    }
                    int output = selector.Run();
                    selector.Clear();
                    Console.Clear();
                    currentFile = fileList[output];
                    if (Verify())
                    {
                        string[] currentFileAsArray = new string[1];
                        currentFileAsArray[0] = currentFile;
                        File.WriteAllLines("lastUsed.csv", currentFileAsArray);
                    }
                    else
                    {
                        System.Console.WriteLine("Något är fel med filen. Återställer.");
                        Restore();
                    }
                    return true;
                }
                else
                {
                    System.Console.WriteLine("Det finns inga filer. Tryck på en knapp för att fortsätta.");
                    Console.ReadLine();
                    return false;
                }
            }
        }
        static void Restore()
        {

            int tableAmount;
            if (File.ReadAllLines(currentFile).Length < 1)
            {
                tableAmount = 8;
            }
            else
            {
                tableAmount = File.ReadAllLines(currentFile).Length;
            }
            string fileName = currentFile;
            List<string> bas = new List<string>();
            File.Create(fileName).Close();
            for (int i = 0; i < tableAmount; i++)
            {
                bas.Add($"{i + 1}{defaultInfo}");
            }
            File.WriteAllLines($"{fileName}", bas);
            System.Console.WriteLine($"Filen har återställts och har nu {tableAmount} bord. Tryck på en knapp för att fortsätta.");
            Console.ReadLine();
        }
        static void CreateFile()
        {
            int tableAmount = 0;
            bool first = true;
            System.Console.WriteLine("Skriv hur många bord du vill ha");
            bool integer = false;
            while (!integer || tableAmount < 1)
            {
                if (!first)
                {
                    System.Console.WriteLine("Fel sorts input");
                }
                else
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
                    List<string> bas = new List<string>();
                    File.Create(fileName + ".txt").Close();
                    for (int i = 0; i < tableAmount; i++)
                    {
                        bas.Add($"{i + 1}{defaultInfo}");
                    }
                    File.WriteAllLines($"{fileName}.txt", bas);
                }
            }
            else
            {
                List<string> bas = new List<string>();
                File.Create(fileName + ".txt").Close();
                for (int i = 0; i < tableAmount; i++)
                {
                    bas.Add($"{i + 1}{defaultInfo}");
                }
                File.WriteAllLines($"{fileName}.txt", bas);
            }
        }
        static void DeleteFile()
        {
            Console.Clear();
            string[] fileList = Directory.GetFiles($"{Directory.GetCurrentDirectory()}", "*.txt");
            if (fileList.Length > 0)
            {
                System.Console.WriteLine("Välj filen du vill ta bort:");
                Selector selector = new Selector();
                selector.AddRange(fileList);
                int output = selector.Run();
                selector.Clear();
                Console.Clear();
                string selectedFile = fileList[output];
                System.Console.WriteLine($"Är du säker du vill ta bort {selectedFile}?");
                selector.Add("Ja");
                selector.Add("Nej");
                output = selector.Run();
                selector.Clear();
                Console.Clear();
                if (output == 0) File.Delete(selectedFile);
            }
            else
            {
                System.Console.WriteLine("Det finns inga filer. Tryck på en knapp för att fortsätta.");
                Console.ReadLine();
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
                    Thread.Sleep(2);
                    Console.Write(write.Substring(i, 1));
                }

            }
            else
            {
                int i;
                for (i = 0; i <= write.Length - 1; i++)
                {
                    Thread.Sleep(2);
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