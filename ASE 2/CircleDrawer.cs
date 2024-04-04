using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_2
{
    /// <summary>
    /// Provides functionality to draw circles on a graphics surface.
    /// </summary>
    public class CircleDrawer
    {
        private Graphics g;
        private Pen pen;
        private Brush brush;

        /// <summary>
        /// Initializes a new instance of the CircleDrawer class with the specified graphics, pen, and brush.
        /// </summary>
        /// <param name="graphics">The graphics object to draw on.</param>
        /// <param name="pen">The pen used to draw the circle's outline.</param>
        /// <param name="brush">The brush used to fill the circle's interior.</param>
        public CircleDrawer(Graphics graphics, Pen pen, Brush brush)
        {
            this.g = graphics;
            this.pen = pen;
            this.brush = brush;
        }

        /// <summary>
        /// Draws a circle with the specified radius and center coordinates.
        /// </summary>
        /// <param name="circleRadius">The radius of the circle.</param>
        /// <param name="x">The x-coordinate of the center of the circle.</param>
        /// <param name="y">The y-coordinate of the center of the circle.</param>
        public void DrawCircle(int circleRadius, int x, int y)
        {
            Rectangle circleBounds = new Rectangle(x - circleRadius, y - circleRadius, 2 * circleRadius, 2 * circleRadius);
            g.DrawEllipse(pen, circleBounds);
        }
    }
}
