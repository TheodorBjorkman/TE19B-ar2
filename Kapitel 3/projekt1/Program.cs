using System;

namespace projekt1
{
    static class pVar {
        static public bool haveTorch = false;
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
        static void Main(string[] args)
        {
            if(pVar.location == 0) {
                Outside();
            } else if 


        }
        static void Write(bool line, string write) {

            if(line == false) {

                Console.Write(write);

            } else {

                System.Console.WriteLine(write);

            }
        }
        static void Outside() {
            if(pVar.first0 == true){
                Write(false, "You are standing in front of a cave entrance located at the foot of a mountain. There is an outhouse a few meters to the left of the entrance and a torch leaned on the right of the opening. Where do you go? ");
                pVar.first0 = false;
            } else {
                Write(false, "You are outside the cave. Where do you go? ");
            }
            string input = Console.ReadLine();

            input = input.ToLower();

            if(input == "outhouse") {

                Outhouse();

            } else if(input == "cave") {

                Write(true, "Cave");

            } else if(input == "torch" && pVar.haveTorch == false) {

                pVar.haveTorch = true;
                Write(false, "You picked up the torch and walked back.");
                Outside();

            } else {

                Write(false, "That is not a valid choice.");
                Outside();
            }
        }
        static void Outhouse() {
            if(pVar.first1 == true) {
                var rand = new Random();
                int random = rand.Next(101);
                if(random >= 20) {
                    pVar.swordExist = true;
                }
            }
            Write(true, "You now stand next to the outhouse");
        }

        static void Cave() {
            
        }
    }
}
