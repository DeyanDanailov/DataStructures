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
            var ticks = 0;
            var line = Console.ReadLine();
            while (!line.Equals("end"))
            {
                var cmdArgs = line.Split();
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
                            if (cmdArgs[0].Equals("move"))
                            {
                                var id = cmdArgs[1];
                                var x = int.Parse(cmdArgs[2]);
                                var y = int.Parse(cmdArgs[3]);
                                byId[id].X1 = x;
                                byId[id].Y1 = y;
                            }

                            Sweep(ticks, items);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private static void Sweep(int ticks, List<Item> items)
        {
            InsertionSort(items );
        }

        private static void InsertionSort(List<Item> items)
        {
            for (int i = 1; i < items.Count; i++)
            {
                var j = i;
                while (j>0 && items[j -1].X1 > items[j].X1)
                {
                    Swap(j-1, j , items);
                    j--;
                }
            }
        }

        private static void Swap(int v, int j, List<Item> items) // Swap places of items
        {
            var temp = items[v];
            items[v] = items[j];
            items[j] = temp;
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
