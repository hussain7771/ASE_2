using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_2
{
    /// <summary>
    /// A class for drawing rectangles on a graphics surface.
    /// </summary>
    public class RectangleDrawer
    {
        private Graphics g;
        private Pen pen;
        private Brush brush;

        /// <summary>
        /// Initializes a new instance of the RectangleDrawer class.
        /// </summary>
        /// <param name="graphics">The graphics object on which to draw.</param>
        /// <param name="pen">The pen used to draw the rectangle outline.</param>
        /// <param name="brush">The brush used to fill the rectangle.</param>
        public RectangleDrawer(Graphics graphics, Pen pen, Brush brush)
        {
            this.g = graphics;
            this.pen = pen;
            this.brush = brush;
        }

        /// <summary>
        /// Draws a rectangle on the graphics surface with the specified width, height, and position.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="x">The x-coordinate of the top-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the top-left corner of the rectangle.</param>
        public void DrawRectangle(int width, int height, int x, int y)
        {
            g.DrawRectangle(pen, x, y, width, height);
        }
    }
}
