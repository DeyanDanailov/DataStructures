using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var symbolsCounter = new SortedDictionary<char, int>();
            var input = Console.ReadLine();
            foreach (var symbol in input)
            {
                if (!symbolsCounter.ContainsKey(symbol))
                {
                    symbolsCounter[symbol] = 0;
                }
                symbolsCounter[symbol]++;
            }
            foreach (var kvp in symbolsCounter)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
