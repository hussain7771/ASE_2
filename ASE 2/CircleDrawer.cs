using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_2
{
    public class CircleDrawer
    {
        private Graphics g;
        private Pen pen;
        private Brush brush;


        public CircleDrawer(Graphics graphics, Pen pen, Brush brush)
        {
            this.g = graphics;
            this.pen = pen;
            this.brush = brush;

        }

        public void DrawCircle(int circleRadius, int x, int y)
        {

            Rectangle circleBounds = new Rectangle(x - circleRadius, y - circleRadius, 2 * circleRadius, 2 * circleRadius);

            g.DrawEllipse(pen, circleBounds);


        }
    }
}
