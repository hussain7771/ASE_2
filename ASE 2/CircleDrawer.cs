using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_2
{
    /// <summary>
    /// A class for drawing circles on a graphics surface.
    /// </summary>
    public class CircleDrawer
    {
        private Graphics g;
        private Pen pen;
        private Brush brush;

        /// <summary>
        /// Initializes a new instance of the CircleDrawer class.
        /// </summary>
        /// <param name="graphics">The graphics object on which to draw.</param>
        /// <param name="pen">The pen used to draw the circle outline.</param>
        /// <param name="brush">The brush used to fill the circle.</param>
        public CircleDrawer(Graphics graphics, Pen pen, Brush brush)
        {
            this.g = graphics;
            this.pen = pen;
            this.brush = brush;
        }

        /// <summary>
        /// Draws a circle on the graphics surface with the specified radius and position.
        /// </summary>
        /// <param name="circleRadius">The radius of the circle.</param>
        /// <param name="x">The x-coordinate of the center of the circle.</param>
        /// <param name="y">The y-coordinate of the center of the circle.</param>
        public void DrawCircle(int circleRadius, int x, int y)
        {
            // Calculate the bounding rectangle for the circle
            Rectangle circleBounds = new Rectangle(x - circleRadius, y - circleRadius, 2 * circleRadius, 2 * circleRadius);

            // Draw the circle outline
            g.DrawEllipse(pen, circleBounds);
        }
    }
}
