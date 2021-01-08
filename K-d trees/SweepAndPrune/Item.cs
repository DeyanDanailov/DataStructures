

namespace SweepAndPrune
{
    public class Item
    {
        public Item(string id, int x1, int y1)
        {
            this.Id = id;
            this.X1 = x1;
            this.Y1 = y1;
        }
        public string Id { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get { return this.X1 + 10; } }
        public int Y2 { get { return this.Y1 + 10; } }

        public bool Intersects(Item that)
        {
            return 
                this.X1 <= that.X2 &&
                this.X2 >= that.X1 &&
                this.Y1 <= that.Y2 &&
                this.Y2 >= that.Y1;
        }
    }
}
