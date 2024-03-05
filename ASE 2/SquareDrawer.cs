using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_2
{
    public class SquareDrawer
    {
        private Graphics g;
        private Pen pen;

        public SquareDrawer(Graphics graphics, Pen pen)
        {
            this.g = graphics;
            this.pen = pen;
        }

        public void DrawSquare(int size, int x, int y)
        {  
            // Draw a square using the specified size and location sfsw 
            g.DrawRectangle(pen, x, y, size, size);
        }
    }
}
