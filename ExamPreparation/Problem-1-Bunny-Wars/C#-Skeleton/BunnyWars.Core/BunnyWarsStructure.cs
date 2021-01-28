namespace BunnyWars.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BunnyWarsStructure : IBunnyWarsStructure
    {
        //private SortedSet<int> roomsById;
        private SortedDictionary<int, SortedSet<Bunny>> bunniesByRooms;
        public BunnyWarsStructure()
        {
            //this.roomsById = new LinkedList<int>();
            this.bunniesByRooms = new SortedDictionary<int, SortedSet<Bunny>>();
        }
        public int BunnyCount { get { return bunniesByRooms.Values.Select(x => x.Count).Sum(); } }

        public int RoomCount { get { return bunniesByRooms.Count; } }

        public void AddRoom(int roomId)
        {
            if (bunniesByRooms.ContainsKey(roomId))
            {
                throw new ArgumentException("Room ID already exists!");
            }
            bunniesByRooms.Add(roomId, new SortedSet<Bunny>());
        }

        public void AddBunny(string name, int team, int roomId)
        {
            throw new NotImplementedException();
        }

        public void Remove(int roomId)
        {
            throw new NotImplementedException();
        }

        public void Next(string bunnyName)
        {
            throw new NotImplementedException();
        }

        public void Previous(string bunnyName)
        {
            throw new NotImplementedException();
        }

        public void Detonate(string bunnyName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bunny> ListBunniesByTeam(int team)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bunny> ListBunniesBySuffix(string suffix)
        {
            throw new NotImplementedException();
        }
    }
}
