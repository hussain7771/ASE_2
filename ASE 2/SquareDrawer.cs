using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ASE_2
{
    /// <summary>
    /// A class for drawing squares on a graphics surface.
    /// </summary>
    public class SquareDrawer
    {
        private Graphics g;
        private Pen pen;

        /// <summary>
        /// Initializes a new instance of the SquareDrawer class.
        /// </summary>
        /// <param name="graphics">The graphics object on which to draw.</param>
        /// <param name="pen">The pen used to draw the square.</param>
        public SquareDrawer(Graphics graphics, Pen pen)
        {
            this.g = graphics;
            this.pen = pen;
        }

        /// <summary>
        /// Draws a square on the graphics surface with a default implementation.
        /// </summary>
        public static void DrawSquare()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Draws a square on the graphics surface at the specified location and size.
        /// </summary>
        /// <param name="size">The size of the square.</param>
        /// <param name="x">The x-coordinate of the top-left corner of the square.</param>
        /// <param name="y">The y-coordinate of the top-left corner of the square.</param>
        public void DrawSquare(int size, int x, int y)
        {
            // Draw a square using the specified size and location
            g.DrawRectangle(pen, x, y, size, size);
        }
    }
}
