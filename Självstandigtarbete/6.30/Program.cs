using System;

namespace _6._30
{
    class Program
    {
        static int[] cards = { 5 };
        static void Main()
        {
            int total = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                int counter = 0;
                int add = cards[i];
                bool yes = false;
                for (int j = 0; j < i; j++)
                {
                    if (cards[i] == cards[j])
                    {
                        yes = true;
                        break;
                    }
                }
                if (yes) continue;
                for (int j = 0; j < cards.Length; j++)
                {
                    if (cards[i] == cards[j]) counter++;
                }
                for (int j = 0; j < counter - 1; j++) add = add * cards[i];
                total += add;
            }
            System.Console.WriteLine(total);
        }
    }
}
