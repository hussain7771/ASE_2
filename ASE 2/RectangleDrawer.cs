using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_2
{
    public class RectangleDrawer
    {
        private Graphics g;
        private Pen pen;
        private Brush brush;

        public RectangleDrawer(Graphics graphics, Pen pen, Brush brush)
        {
            this.g = graphics;
            this.pen = pen;
            this.brush = brush;
        }

        public void DrawRectangle(int width, int height, int x, int y)
        {
            g.DrawRectangle(pen, x, y, width, height);
        }
    }
}
