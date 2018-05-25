using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    [Serializable]
    public class Line
    {
        public int CoordX { get; set; }
        public int CoordY { get; set; }
        public int CoordX2 { get; set; }
        public int CoordY2 { get; set; }
        public Color Color { get; set; }
        public Line() { }
        public Line(int x, int y, int x2, int y2, Color cl)
        {
            CoordX = x;
            CoordY = y;
            CoordX2 = x2;
            CoordY2 = y2;
            Color = cl;
        }
    }
}
