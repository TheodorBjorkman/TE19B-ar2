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
        static public bool chestTrap = false;
        static public bool dog = false;
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
            random = new Random().Next(0, 101);
                if(random <= 80) 
                {
                    pVar.chestTrap = true;
                }

            Location();
            
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
                    Thread.Sleep(20);
                 Console.Write(write.Substring(i, 1));
                    }

            } else 
            {
                int i;
                for(i = 0; i <= write.Length - 1; i++)
                {
                    Thread.Sleep(20);
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
                pVar.first1 = true;
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
            if(pVar.haveTorch == true && pVar.litTorch == false) 
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
                } else if(pVar.haveTorch == true && pVar.litTorch == true)
                {
                    Write(true, "Opening the door of the outhouse, a pungent smell hits you like a wave before your torch caused the accumulated gasses in the small shed to explode. You died.");

                } else
                {
                    Write(false, "Perhaps if you had a light source you could make something out. You walk back out. ");
                    Outhouse();
                }
        }

        static void Cave() 
        {
            string input;
            if(pVar.first1 == true) 
            {
                Write(true, "You entered the cave, it is dark but the light of the moon and stars allow you to see two tunnels seperating from the entrance.");
                pVar.first1 = false;
            }
            
            if(pVar.haveTorch == true && pVar.litTorch == false)
            {
                Write(false, "Do you walk back, forward, left or light your torch? ");
                input = Console.ReadLine();
                if(input == "back" || input == "out")
                {
                    Write(true, "You walk back out.");
                    Outside();
                } else if(input == "forward")
                {
                    Write(true, "You walk forward.");
                    CaveForward();
                } else if(input == "left")
                {
                    CaveLeft();
                } else if(input == "torch" || input == "light" || input == "light torch")
                {
                    Write(true, "The light of your torch reveals a third tunnel hidden in the shadows to your right.");
                    pVar.litTorch = true;
                    Cave();
                } else 
                {
                    Write(true, "Invalid choice.");
                    Cave();
                }
            } else if(pVar.haveTorch == true && pVar.litTorch == true)
            {
                Write(false, "Do you walk back, forward, left or right? ");
                input = Console.ReadLine();
                if(input == "back" || input == "out")
                {
                    Write(true, "You step back out.");
                    Outside();
                } else if(input == "forward")
                {
                    Write(true, "You walk forward.");
                    CaveForward();
                } else if(input == "left")
                {
                    Write(true, "You took the path to the left.");
                    CaveLeft();
                } else if(input == "right")
                {
                    Write(true, "You enter the hidden cave.");
                    CaveHidden();
                } else 
                {
                    Write(true, "Invalid choice.");
                    Cave();
                }
            } else if(pVar.haveTorch == false)
            {
                Write(false, "Do you walk back, forward or left? ");
                input = Console.ReadLine();
                if(input == "back" || input == "out")
                {
                    Write(true, "You step back out.");
                    Outside();
                } else if(input == "forward")
                {
                    Write(true, "You walk forward.");
                    CaveForward();
                } else if(input == "left")
                {
                    Write(true, "You took the path to the left.");
                    CaveLeft();
                } else 
                {
                    Write(true, "Invalid choice.");
                    Cave();
                }
            }
        }
        static void CaveLeft()
        {
            string input;
            Write(true, "CaveLeft");
        }
        static void CaveHidden()
        {
            string input;
            if(pVar.dog == true) 
            {
                Write(true, "You feel a strong sense of dissapointment as you watch the open chest. You turn around and head back.");
            }
            Write(true, "You step inside a roomy part of the cave, moonlight shining through a hole in the roof. It is a dead end with a suspicious chest laying in front of the cave wall.");
            Write(false, "Will you open the chest or go back out? ");
            input = Console.ReadLine();
            if(input == "open" || input == "open chest" || input == "chest")
            {
                if(pVar.chestTrap == true)
                {
                    Write(true, "As you open the chest you hear a small twang and feel a prick in your stomach before everything starts to fade. You died.");

                } else
                {
                    Write(true, "You open the chest finding an artifact of immense power.");
                    Thread.Sleep(1000);
                    Write(true, "A small white dog jumps into the chest from behind you and absorbs the artifact. \nThe dog phases through the floor leaving only some white dust behind.");
                    Thread.Sleep(2000);
                    Write(true, "You walk back to the cave entrance.");
                    Thread.Sleep(1000);
                    pVar.dog = true;
                    Cave();
                }
            } else if(input == "back" || input == "out")
            {
                Write(true, "You turn around and head back.");
                Cave();
            }
        }
        static void CaveForward()
        {
            string input;
            Write(true, "CaveForward");
        }
    }
}
