namespace BunnyWars.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class BunnyWarsStructure : IBunnyWarsStructure
    {
        private List<int> roomsById;
        private OrderedDictionary<int, SortedSet<Bunny>> bunniesByRooms;
        private Dictionary<string, Bunny> bunniesByName;
        private Dictionary<int, SortedSet<Bunny>> bunniesByTeam;
        public BunnyWarsStructure()
        {
            this.roomsById = new List<int>();
            this.bunniesByRooms = new OrderedDictionary<int, SortedSet<Bunny>>();
            this.bunniesByName = new Dictionary<string, Bunny>();
            this.bunniesByTeam = new Dictionary<int, SortedSet<Bunny>>();
        }
        public int BunnyCount { get { return bunniesByRooms.Values.Select(x => x.Count).Sum(); } private set { } }

        public int RoomCount { get { return bunniesByRooms.Count; } }

        public void AddRoom(int roomId)
        {
            if (bunniesByRooms.ContainsKey(roomId))
            {
                throw new ArgumentException("Room ID already exists!");
            }
            bunniesByRooms.Add(roomId, new SortedSet<Bunny>());
            roomsById.Add(roomId);
            roomsById = roomsById.OrderBy(x => x).ToList();
        }

        public void AddBunny(string name, int team, int roomId)
        {
            
            if (this.bunniesByName.ContainsKey(name))
            {
                throw new ArgumentException("Bunny name already exists!");
            }
            CheckTeam(team);
            if (!bunniesByTeam.ContainsKey(team))
            {
                bunniesByTeam[team] = new SortedSet<Bunny>();
            }
            var bunny = new Bunny(name, team, roomId);
            bunniesByTeam[team].Add(bunny);
            if (!bunniesByRooms.ContainsKey(roomId))
            {
                throw new ArgumentException("Room doesn't exist!");
            }
            
            bunniesByName.Add(name, bunny);
            if (!bunniesByRooms.ContainsKey(roomId))
            {
                bunniesByRooms.Add(roomId, new SortedSet<Bunny>());
            }
            bunniesByRooms[roomId].Add(bunny);
            this.BunnyCount++;
        }

        private static void CheckTeam(int team)
        {
            if (team < 0 || team > 4)
            {
                throw new IndexOutOfRangeException("Invalid Team number!");
            }
        }

        public void Remove(int roomId)
        {
            if (!bunniesByRooms.ContainsKey(roomId))
            {
                throw new ArgumentException("Room doesn't exist!");
            }
            //bunniesByRooms[roomId].Clear();
            bunniesByRooms.Remove(roomId);
            roomsById.Remove(roomId);
        }

        public void Next(string bunnyName)
        {
            CheckBunnyExists(bunnyName);
            var bunny = bunniesByName[bunnyName];
            bunniesByRooms[bunny.RoomId].Remove(bunny);
            var myKey = bunny.RoomId;
            if (myKey + 1 > roomsById.Count -1)
            {
                myKey = 0;
            }
            else
            {
                myKey++;
            }
            var newKey = roomsById[myKey];
            bunniesByRooms[newKey].Add(bunny);         
        }

        public void Previous(string bunnyName)
        {
            CheckBunnyExists(bunnyName);
            var bunny = bunniesByName[bunnyName];
            bunniesByRooms[bunny.RoomId].Remove(bunny);
            var myKey = bunny.RoomId;
            if (myKey - 1 < 0)
            {
                myKey = roomsById.Count - 1;
            }
            else
            {
                myKey--;
            }
            var newKey = roomsById[myKey];
            bunniesByRooms[newKey].Add(bunny);
        }


        public void Detonate(string bunnyName)
        {
            CheckBunnyExists(bunnyName);
            var detonator = bunniesByName[bunnyName];
            var team = detonator.Team;
            var room = detonator.RoomId;
            var bunniesToRemove = new List<Bunny>();
            foreach (var bunny in bunniesByRooms[room])
            {
                if (bunny.Team != team)
                {
                    bunny.Health -= 30;
                    if (bunny.Health <= 0)
                    {
                        bunniesToRemove.Add(bunny);                      
                        this.BunnyCount--;
                        detonator.Score++;
                    }
                }
            }
            foreach (var bunny in bunniesToRemove)
            {
                bunniesByRooms[room].Remove(bunny);
                bunniesByName.Remove(bunny.Name);
                bunniesByTeam[bunny.Team].Remove(bunny);
            }
        }

        public IEnumerable<Bunny> ListBunniesByTeam(int team)
        {
            CheckTeam(team);
            return bunniesByTeam[team];
        }

        public IEnumerable<Bunny> ListBunniesBySuffix(string suffix)
        {
            throw new NotImplementedException();
        }
        private void CheckBunnyExists(string bunnyName)
        {
            if (!bunniesByName.ContainsKey(bunnyName))
            {
                throw new ArgumentException("Bunny doesn't exist!");
            }
        }
    }
}
