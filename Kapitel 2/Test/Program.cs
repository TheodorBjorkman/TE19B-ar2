using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Skriv din email: ");
            string email = Console.ReadLine();

            string protocol = email.Substring(0, email.IndexOf(":") + 3);
            Console.WriteLine(protocol);

            string subdomain = email.Substring(email.IndexOf(":") + 3, email.IndexOf("." + 1));
            Console.WriteLine(subdomain);

            string domain = email.Substring(email.IndexOf(".") + 1, email.IndexOf(".") + 1);
            Console.WriteLine(domain);

            string topLevelDomain = email.Substring(email.IndexOf(".", email.IndexOf("." + 1)) + 3, email.IndexOf("/" + 1));
            Console.WriteLine(topLevelDomain);

            string path = email.Substring(email.IndexOf("/") + 1);
            Console.WriteLine(path);
        }
    }
}
