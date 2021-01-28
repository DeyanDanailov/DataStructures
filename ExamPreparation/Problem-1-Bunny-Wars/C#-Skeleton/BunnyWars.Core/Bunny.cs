namespace BunnyWars.Core
{
    using System;

    public class Bunny : IComparable<Bunny>
    {
        public Bunny(string name, int team, int roomId)
        {
            this.Name = name;
            this.Team = team;
            this.RoomId = roomId;
            this.Health = 100;
        }

        public int RoomId { get; set; }

        public string Name { get; private set; }

        public int Health { get; set; }

        public int Score { get; set; }

        public int Team { get; private set; }

        public int CompareTo(Bunny other)
        {
            int cmp = this.Name.CompareTo(other.Name);
            if (cmp == 1)
            {
                return -1;
            }
            if (cmp == -1)
            {
                return 1;
            }
            return cmp;
        }
    }
}
