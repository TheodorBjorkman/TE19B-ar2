using System;
using System.Threading;
//highlight answers
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
        static public bool potion = false;
        static public int hpWolf = 9;
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
        static public bool first3 = true;

        static public int hp = 12;
        static public int atk = 0;
    }
    class Program
    {
        static void Main() //initialization
        {
            int random = new Random().Next(0, 101);
            if (random >= 20)
            {
                pVar.swordExist = true;
            }
            random = new Random().Next(0, 101);
            if (random <= 80)
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
                case 3:
                    Fight();
                    break;
            }
        }
        static void Write(bool line, string write) //cool writing system
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
        static void Outside()
        {
            if (pVar.first0 == true)
            {
                Write(false, "You are standing in front of a cave entrance located at the foot of a mountain. There is an outhouse a few meters to the left of the entrance and a torch leaned on the right of the opening. Where do you go? ");
                pVar.first0 = false;
            }
            else
            {
                Write(false, "You are outside the cave. Where do you go? ");
            }
            string input = Console.ReadLine();
            input = input.ToLower();

            if (input == "outhouse")
            {

                Outhouse();

            }
            else if (input == "cave")
            {
                pVar.first1 = true;
                Cave();

            }
            else if (input == "torch" && pVar.haveTorch == false)
            {

                pVar.haveTorch = true;
                Write(true, "You picked up the torch and walked back.");
                Outside();

            }
            else
            {

                Write(true, "That is not a valid choice.");
                Outside();
            }
        }
        static void Outhouse()
        {
            if (pVar.first1 == true)
            {

            }
            Write(false, "You stand next to the outhouse. Do you go look around, go inside or go back? ");
            string input = Console.ReadLine();
            input = input.ToLower();
            if (input == "look around" || input == "look" || input == "around")
            {
                if (pVar.swordExist == true)
                {
                    Write(true, "You found a rusty sword! You swapped your sturdy stick for it.");
                    pVar.atk = 2;
                    Outhouse();
                }
                else
                {
                    Write(true, "There was nothing there.");
                    Outhouse();
                }
            }
            else if (input == "inside" || input == "go inside")
            {
                Write(false, "You stepped inside. It smells atrocius and is too dark to see anything. ");
                inOuthouse();
            }
            else if (input == "back" || input == "go back")
            {
                Write(true, "You go back.");
                Outside();
            }
        }

        static void inOuthouse()
        {
            if (pVar.haveTorch == true && pVar.litTorch == false)
            {
                Write(false, "Light your torch? ");
                string boll = Console.ReadLine();
                boll = boll.ToLower();
                if (boll == "yes" || boll == "y")
                {
                    Write(true, "As you use your flint and steel the sparks start an explosion. You are dead.");

                }
                else if (boll == "no" || boll == "n")
                {
                    Write(true, "You walk back out");
                    Outhouse();
                }
                else
                {
                    Write(true, "Invalid choice.");
                    inOuthouse();
                }
            }
            else if (pVar.haveTorch == true && pVar.litTorch == true)
            {
                Write(true, "Opening the door of the outhouse, a pungent smell hits you like a wave before your torch caused the accumulated gasses in the small shed to explode. You died.");

            }
            else
            {
                Write(false, "Perhaps if you had a light source you could make something out. You walk back out. ");
                Outhouse();
            }
        }

        static void Cave()
        {
            string input;
            if (pVar.first1 == true)
            {
                Write(true, "You entered the cave, it is dark but the light of the moon and stars allow you to see two tunnels seperating from the entrance.");
                pVar.first1 = false;
            }

            if (pVar.haveTorch == true && pVar.litTorch == false)
            {
                Write(false, "Do you walk back, forward, left or light your torch? ");
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "back" || input == "out")
                {
                    Write(true, "You walk back out.");
                    Outside();
                }
                else if (input == "forward")
                {
                    Write(true, "You walk forward.");
                    CaveForward();
                }
                else if (input == "left")
                {
                    CaveLeft();
                }
                else if (input == "torch" || input == "light" || input == "light torch")
                {
                    Write(true, "The light of your torch reveals a third tunnel hidden in the shadows to your right.");
                    pVar.litTorch = true;
                    Cave();
                }
                else
                {
                    Write(true, "Invalid choice.");
                    Cave();
                }
            }
            else if (pVar.haveTorch == true && pVar.litTorch == true)
            {
                Write(false, "Do you walk back, forward, left or right? ");
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "back" || input == "out")
                {
                    Write(true, "You step back out.");
                    Outside();
                }
                else if (input == "forward")
                {
                    Write(true, "You walk forward.");
                    CaveForward();
                }
                else if (input == "left")
                {
                    Write(true, "You took the path to the left.");
                    CaveLeft();
                }
                else if (input == "right")
                {
                    Write(true, "You enter the hidden cave.");
                    CaveHidden();
                }
                else
                {
                    Write(true, "Invalid choice.");
                    Cave();
                }
            }
            else if (pVar.haveTorch == false)
            {
                Write(false, "Do you walk back, forward or left? ");
                input = Console.ReadLine();
                input = input.ToLower();
                if (input == "back" || input == "out")
                {
                    Write(true, "You step back out.");
                    Outside();
                }
                else if (input == "forward")
                {
                    Write(true, "You walk forward.");
                    CaveForward();
                }
                else if (input == "left")
                {
                    Write(true, "You took the path to the left.");
                    CaveLeft();
                }
                else
                {
                    Write(true, "Invalid choice.");
                    Cave();
                }
            }
        }
        static void CaveLeft()
        {
            if (pVar.hpWolf <= 0)
            {
                CaveLeft2();
            }
            string input;
            Write(false, "As you walked into a larger section of the tunnel, large enough to call a room, you hear a growl infront as you see a wolf prowl from the tunnel ahead. You hold up your weapon. Do you fight or flee? ");
            input = Console.ReadLine();
            input = input.ToLower();
            if (input == "flee" || input == "escape")
            {
                int random = new Random().Next(0, 101);
                if (random <= 50)
                {
                    Write(true, "The wolf chased you down and felled you as you were running. You died.");
                }
                else
                {
                    Write(true, "The wolf stayed as you walked backwards to the cave entrance.");
                    Cave();
                }
            }
            else if (input == "fight")
            {
                Write(true, "You and the wolf press forward in sync, circling one another in the room.");
                Fight();
            }
        }
        static void CaveHidden()
        {
            string input;
            switch (pVar.dog)
            {
                case true:
                    Write(true, "You feel a strong sense of dissapointment as you watch the open chest. You turn around and head back.");
                    Cave();
                    break;
                case false:
                    Write(true, "You step inside a roomy part of the cave, moonlight shining through a hole in the roof. It is a dead end with a suspicious chest laying in front of the cave wall.");
                    Write(false, "Will you open the chest or go back out? ");
                    input = Console.ReadLine();
                    input = input.ToLower();
                    if (input == "open" || input == "open chest" || input == "chest")
                    {
                        if (pVar.chestTrap == true)
                        {
                            Write(true, "As you open the chest you hear a small twang and feel a prick in your stomach before everything starts to fade. You died.");

                        }
                        else
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
                    }
                    else if (input == "back" || input == "out")
                    {
                        Write(true, "You turn around and head back.");
                        Cave();
                    }
                    break;
            }
        }
        static void CaveForward()
        {
            if (pVar.first3 == true)
            {
                Write(true, "You walk forward finding a glass flask with a bright red liquid giving off some red light. You pick it up and head back.");
                pVar.potion = true;
            }
            else
            {
                Write(true, "There is nothing else here, only a dead end. You head back.");
            }
            Cave();
        }
        static void Fight()
        {
            pVar.location = 3;
            if (pVar.hpWolf <= 0)
            {
                CaveLeft2();
            }
            string input;
            Write(false, "Attack, block or use potion? ");
            input = Console.ReadLine();
            input = input.ToLower();
            switch (input)
            {
                case "attack":
                    Write(true, "You slash at the wolf with your weapon hitting it but getting slashed by claws in return");
                    int random = new Random().Next(0, 4);
                    Thread.Sleep(3);
                    int random2 = new Random().Next(1, 3);
                    pVar.hp = pVar.hp - (random + 3);
                    pVar.hpWolf = pVar.hpWolf - (random2 - pVar.atk);
                    hpCheck();
                    break;

                case "block":


                    int damage;
                    int success = new Random().Next(0, 3);
                    if (success <= 2)
                    {
                        if (pVar.litTorch == true)
                        {
                            Write(true, "You block the wolfs bite with your torch burning its face while getting slightly burnt yourself.");
                            damage = new Random().Next(0, 1);
                            int damage2 = new Random().Next(0, 3);
                            pVar.hp = pVar.hp - (damage + 1);
                            pVar.hpWolf = pVar.hpWolf - (damage2 + 3);
                            hpCheck();
                        }
                        else if (pVar.litTorch == false)
                        {
                            Write(true, "You block the wolfs bite attack, throwing it to the side dealing slight amounts of damage.");
                            damage = new Random().Next(0, 2);
                            pVar.hpWolf = pVar.hpWolf - (damage + 2);
                            hpCheck();
                        }
                    }
                    else
                    {
                        Write(true, "You fail to block the wolfs attack taking massive damage.");
                        damage = new Random().Next(0, 2);
                        pVar.hp = pVar.hp - (damage + 7);
                        hpCheck();
                    }
                    break;
                case "potion":

                    if (pVar.potion == true)
                    {
                        Write(true, "You drink the red potion");
                        int healing = new Random().Next(0, 6);
                        pVar.hp = pVar.hp + healing + 2;
                        hpCheck();
                    }
                    else
                    {
                        Write(true, "You don't have a potion.");
                        hpCheck();
                    }
                    break;
            }
        }
        static void hpCheck()
        {
            if (pVar.hp >= 12)
            {
                Write(true, "You are undamaged");
                Location();
            }
            else if (pVar.hp >= 10)
            {
                Write(true, "You are slightly hurt");
                Location();
            }
            else if (pVar.hp >= 6)
            {
                Write(true, "You are hurt");
                Location();
            }
            else if (pVar.hp >= 4)
            {
                Write(true, "You are dying");
                Location();
            }
            else if (pVar.hp >= 1)
            {
                Write(true, "You are almost dead");
                Location();
            }
            else
            {
                Write(true, "You died.");
            }
        }
        static void CaveLeft2()
        {
            string input;
            Write(false, "There lies a dead wolf in this room, go forward or back? ");
            input = Console.ReadLine();
            input = input.ToLower();
            if (input == "forward")
            {
                Write(true, "You walk to the next part of the cave.");
                CaveEnd();
            }
            else if (input == "back")
            {
                Write(true, "You go back");
                Cave();
            }
            else
            {
                Write(true, "Invalid choice.");
                CaveLeft2();
            }
        }
        static void CaveEnd()
        {
            Write(true, "As you near the end of the cave, you can finally see the treasure that made you come all this way.");
            Thread.Sleep(100);
            Write(true, "As you take a bite out of the savory chocolate cake you find that it tastes like cardboard.");
            Thread.Sleep(100);
            Write(true, "In fact as you take a closer look you notice that it IS cardboard.");
            Thread.Sleep(100);
            Write(true, "All of this, just to find out that the cake is a lie.");
            Thread.Sleep(100);
            Write(true, "You start the treck back home, thinking to yourself \"This party was awesome, I hope the birthday cake atleast isn't cardboard. I have to thank my friends for making this for me\".");
            System.Environment.Exit(0);
        }
        static void Action()
        {
            System.Console.WriteLine("Helo");
        }
    }
}