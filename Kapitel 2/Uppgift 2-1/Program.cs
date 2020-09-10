using System;

namespace Uppgift_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            float height;
            float less;
            float worldRecord = 2.45F;

            Console.Write("Hur högt kan du hoppa (m)? ");
            height = float.Parse(Console.ReadLine());

less = worldRecord - height - 0.00000005F;

            if (less > 0) {

                Console.WriteLine("Du hoppar " + less + " meter mindre än världsrekordet");
                
            } else {

                Console.WriteLine("Du hoppar högre än världsrekordet!");

            }
            
        }
    }
}
