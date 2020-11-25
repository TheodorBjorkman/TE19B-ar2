using System;
using System.Collections.Generic;

namespace _5._23
{
    class Program
    {
        static void Main()
        {
            int[] num = { 1, 2, 2, 3, 3, 3, 4, 4, 5, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7 };
            int[] amount = new int[num.Length];
            int highestAmount = 0;
            List<int> most = new List<int>();
            for (int i = 0; i < num.Length; i++) for (int j = 0; j < num.Length; j++) if (num[i] == num[j]) amount[i]++;
            for (int i = 0; i < num.Length; i++) if (highestAmount < amount[i]) highestAmount = amount[i];
            for (int i = 0; i < num.Length; i++) for (int j = 0; j < num.Length; j++) if (amount[i] == highestAmount && !most.Contains(num[i])) most.Add(num[i]);
            foreach (int number in most) System.Console.WriteLine(number);
        }
    }
}
