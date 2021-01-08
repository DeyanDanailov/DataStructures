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
            var ticks = 1;
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
                            line = Console.ReadLine();
                            cmdArgs = line.Split();
                            if (cmdArgs[0].Equals("end"))
                            {
                                running = false;
                                break;
                            }
                            if (cmdArgs[0].Equals("move"))
                            {
                                var id = cmdArgs[1];
                                var x = int.Parse(cmdArgs[2]);
                                var y = int.Parse(cmdArgs[3]);
                                byId[id].X1 = x;
                                byId[id].Y1 = y;
                            }

                            Sweep(ticks++, items);
                        }
                        break;
                    default:
                        break;
                }

                line = Console.ReadLine();
            }
        }

        private static void Sweep(int ticks, List<Item> items)
        {
            InsertionSort(items );
            for (int i = 0; i < items.Count; i++)
            {
                var current = items[i];
                for (int j = i+1; j < items.Count; j++)
                {
                    var candidate = items[j];
                    if (candidate.X1 > current.X2)
                    {
                        break;
                    }
                    if (current.Intersects(candidate))
                    {
                        Console.WriteLine("({0}) {1} collides with {2}", ticks, current.Id, candidate.Id);
                    }
                }
            }
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
