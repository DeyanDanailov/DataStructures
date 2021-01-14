using System;
using System.Collections.Generic;

namespace PhoneBook
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var phoneBook = new Dictionary<string, string>();
            var input = Console.ReadLine();
            while (input != "search")
            {
                var cmdArgs = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                phoneBook[cmdArgs[0]] = cmdArgs[1];
                input = Console.ReadLine();
            }
            while (true)
            {
                var person = Console.ReadLine();
                if (phoneBook.ContainsKey(person))
                {
                    Console.WriteLine($"{person} -> {phoneBook[person]}");
                }
                else
                {
                    Console.WriteLine($"Contact {person} does not exist."); 
                }
            }
        }
    }
}
