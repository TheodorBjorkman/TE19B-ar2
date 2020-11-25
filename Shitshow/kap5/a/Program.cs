using System;

namespace a
{
    class Program
    {
        static void Main()
        {
            int[] array = {1, 4, 2, 3, 5};
            int[] över = new int[array.Length];
            int[] under = new int[array.Length];
            int median = 0;
            for (int i = 0; i < array.Length; i++) 
            {
                for (int j = 0; j < array.Length; j++) 
                {
                    if (array[i] < array[j]) 
                    {
                        över[i]++; 
                    }
                    else if (array[i] > array[j]) 
                    {
                        under[i]++;
                    }
                }
            }
            for (int i = 0; i < array.Length; i++) 
            {
                if (över[i] < (array.Length / 2) && under[i] < (array.Length / 2))  
                {
                    median = array[i];
                }
            }
            System.Console.WriteLine(median);
        }
    }
}
