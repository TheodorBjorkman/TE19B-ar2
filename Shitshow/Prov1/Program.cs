using System;

namespace Prov1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklarera variabel + prompting av användare
            int bLön;
            System.Console.WriteLine("Uträkning av nettolön. \nVänligen ange din bruttolön:");
            while (true)
            {
                //Ta in input och kolla om det är ett heltal, sedan kolla om det är över 0. Räkna sedan ut nettolön samtidigt som den skriver meddelandet om nettolönen + uträkningen
                string svar = Console.ReadLine();
                bool flagga = int.TryParse(svar, out bLön);
                if (flagga)
                {
                    if (bLön <= 9999 && bLön > 0)
                    {
                        System.Console.WriteLine($"Din nettolön är: {bLön * 0.92}. Detta räknades ut genom {bLön} * 0.92 då lön under 10'000 har skatten 8%");
                    }
                    else if (bLön <= 144999 && bLön > 0)
                    {
                        System.Console.WriteLine($"Din nettolön är: {bLön * 0.78}. Detta räknades ut genom {bLön} * 0.78 då lön under 155'000 har skatten 22%");
                    }
                    else if (bLön <= 514999 && bLön > 0)
                    {
                        System.Console.WriteLine($"Din nettolön är: {bLön * 0.67}. Detta räknades ut genom {bLön} * 0.67 då lön under 515'000 har skatten 33%");
                    }
                    else if (bLön >= 515000 && bLön > 0)
                    {
                        System.Console.WriteLine($"Din nettolön är: {bLön * 0.47}. Detta räknades ut genom {bLön} * 0.47 då lön över 515'000 har skatten 53%");
                    }
                    else
                    {
                        System.Console.WriteLine("Ange en lön över 0");
                        continue;
                    }
                    //Kolla om dom vill räkna ut en ny lön, om ja loopa om nej stäng programmet
                    while (true)
                    {
                        System.Console.WriteLine("Vill du räkna ut en ny lön? j/n");
                        svar = Console.ReadLine();
                        svar = svar.ToLower();
                        if (svar == "j")
                        {
                            System.Console.WriteLine("Vänligen ange din bruttolön:");
                            break;
                        }
                        else if (svar == "n")
                        {
                            System.Environment.Exit(0);
                        }
                        else
                        {
                            System.Console.WriteLine("Vänligen skriv j för ja eller n för nej");
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("Vänligen ange bruttolön som ett heltal:");
                }
            }
        }
    }
}
//Vill bara klaga på att switch inte kan hantera jämförelser då switch inte kan ta booleans och jämförelser returnar en bool. Annars skulle det här programmet vara lite snyggare. Skulle också kunna använda double för att kunna ha större löner och decimaler men orkar inte.