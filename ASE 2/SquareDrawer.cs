using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_2
{
    /// <summary>
    /// Represents a utility class for drawing squares on a graphics surface.
    /// </summary>
    public class SquareDrawer
    {
        private Graphics g;
        private Pen pen;

        /// <summary>
        /// Initializes a new instance of the SquareDrawer class with the specified graphics and pen.
        /// </summary>
        /// <param name="graphics">The Graphics object to draw on.</param>
        /// <param name="pen">The Pen object to use for drawing the square's outline.</param>
        public SquareDrawer(Graphics graphics, Pen pen)
        {
            this.g = graphics;
            this.pen = pen;
        }

        /// <summary>
        /// Draws a square with the specified size and position.
        /// </summary>
        /// <param name="size">The size of the square (width and height).</param>
        /// <param name="x">The x-coordinate of the top-left corner of the square.</param>
        /// <param name="y">The y-coordinate of the top-left corner of the square.</param>
        public void DrawSquare(int size, int x, int y)
        {
            // Draw a square using the specified size and location
            g.DrawRectangle(pen, x, y, size, size);
        }
    }
}
