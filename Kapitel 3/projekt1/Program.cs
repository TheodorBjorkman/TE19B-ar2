using System;
using System.Threading;

namespace projekt1
{
    static class pVar 
    {
        static public bool haveTorch = false;
        static public bool litTorch = false;
        static public bool haveSword = false;
        static public bool swordExist = false;
        static public int location = 0;
        /*
        Location ID list
        0 = Outside
        1 = Outhouse
        2 = First Caveroom
        */
        static public bool first0 = true;
        static public bool first1 = true;
        static public bool first2 = true;
    }
    class Program
    {
        static void Main() //initialization
        {  
            int random = new Random().Next(0, 101);
                if(random >= 20) 
                {
                    pVar.swordExist = true;
                }
            
        }
        static void Location() //check position
        {
            switch (pVar.location) 
            {
                case 0:
                    Outside();
                    break;
                case 1:
                    Outhouse();
                    break;
                case 2:
                    Cave();
                    break;
            }
        }
        static void Write(bool line, string write) //cool writing system
        {

            if(line == false) 
                {
                int i;
                for(i = 0; i <= write.Length - 1; i++)
                   {
                    Thread.Sleep(50);
                 Console.Write(write.Substring(i, 1));
                    }

            } else 
            {
                int i;
                for(i = 0; i <= write.Length - 1; i++)
                {
                    Thread.Sleep(50);
                    Console.Write(write.Substring(i, 1));
                }
                    System.Console.WriteLine();

            }
        }
        static void Outside() 
        {
            if(pVar.first0 == true)
            {
                Write(false, "You are standing in front of a cave entrance located at the foot of a mountain. There is an outhouse a few meters to the left of the entrance and a torch leaned on the right of the opening. Where do you go? ");
                pVar.first0 = false;
            } else {
                Write(false, "You are outside the cave. Where do you go? ");
            }
            string input = Console.ReadLine();
            input = input.ToLower();

            if(input == "outhouse") 
            {

                Outhouse();

            } else if(input == "cave") 
            {

                Cave();

            } else if(input == "torch" && pVar.haveTorch == false) 
            {

                pVar.haveTorch = true;
                Write(true, "You picked up the torch and walked back.");
                Outside();

            } else {

                Write(true, "That is not a valid choice.");
                Outside();
            }
        }
        static void Outhouse() 
        {
            if(pVar.first1 == true) 
            {
                
            }
            Write(false, "You stand next to the outhouse. Do you go look around, go inside or go back? ");
            string input = Console.ReadLine();
            input = input.ToLower();
            if(input == "look around" || input == "look" || input == "around") 
            {
                if(pVar.swordExist == true) 
                {
                    Write(true, "You found a rusty sword! You swapped your sturdy stick for it.");
                    Outhouse();
                } else 
                {
                    Write(true, "There was nothing there.");
                    Outhouse();
                }
            } else if(input == "inside" || input == "go inside")
            {
                Write(false, "You stepped inside. It smells atrocius and is too dark to see anything. ");
                inOuthouse(); 
            } else if(input == "back" || input == "go back")
            {
                Write(true, "You go back.");
                Outside();
            }
        }

        static void inOuthouse()
        {
            if(pVar.haveTorch == true) 
                {
                    Write(false, "Light your torch? ");
                    string boll = Console.ReadLine();
                    boll = boll.ToLower();
                    if(boll == "yes" || boll == "y")
                    {
                        Write(true, "As you use your flint and steel the sparks start an explosion. You are dead.");
                    } else if(boll == "no" || boll == "n")
                    {
                        Write(true, "You walk back out");
                        Outhouse();
                    } else
                    {
                        Write(true, "Invalid choice.");
                        inOuthouse();
                    }
                } else 
                {
                    Write(false, "Perhaps if you had a light source you could make something out. You walk back out. ");
                    Outhouse();
                }
        }

        static void Cave() 
        {
            Write(true, "lmao");
        }
    }
}
