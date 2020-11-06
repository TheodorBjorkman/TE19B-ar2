using System;

namespace lmao
{
    class Program
    {
        static void Main()
        {
            int[] ålder = new int[100];
            for(int i = 0; i < ålder.Length; i++) ålder[i] = -1;
            for(int i = 0; i < ålder.Length; i++)
            {
                bool num = false;
                while(!num)
                {
                    string s = Console.ReadLine();
                    if(s.ToLower() != "n")
                    {
                        num = int.TryParse(s, out ålder[i]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            for(int i = 0; i < ålder.Length; i++)
            {
                if(ålder[i] > 0)
                {
                    System.Console.WriteLine(ålder[i]);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
