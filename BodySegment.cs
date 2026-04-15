using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class BodySegment
    {
        public int X { get; set; }
        public int Y { get; set; }
        public BodySegment() { }
        public BodySegment(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public (int, int) GetPosition()
        {
            return (X, Y);
        }

        public void ChangePosition(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
