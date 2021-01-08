using System;
using System.Collections.Generic;

namespace SweepAndPrune
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new List<Item>();
            var byId = new Dictionary<string, Item>();

            var running = true;

            var line = Console.ReadLine();
            while (!line.Equals("end"))
            {
                var cmdArgs = line.Split(' ');
                switch (cmdArgs[0])
                {
                    case "add":
                        AddItem(items, byId, cmdArgs);
                        break;
                    case "start":
                        while (running)
                        {
                            if (cmdArgs[0].Equals("end"))
                            {
                                running = false;
                            }

                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void AddItem(List<Item> items, Dictionary<string, Item> byId, string[] cmdArgs)
        {
            var id = cmdArgs[1];
            var x = int.Parse(cmdArgs[2]);
            var y = int.Parse(cmdArgs[3]);
            var item = new Item(id, x, y);
            items.Add(item);
            byId[id] = item;
        }
    }
}
