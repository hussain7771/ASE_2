using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_2;
using System.Drawing.Drawing2D;

namespace ASE_2
{
    [TestClass]
    public class RectangleDrawerTests
    {
        [TestMethod]
        public void DrawRectangle_ValidParameters()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(800, 600);
            Graphics graphics = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Black);
            Brush brush = Brushes.Red;
            RectangleDrawer rectangleDrawer = new RectangleDrawer(graphics, pen, brush);
            int width = 100;
            int height = 50;
            int x = 100;
            int y = 100;

            // Act
            rectangleDrawer.DrawRectangle(width, height, x, y);

            // Assert
            Rectangle expectedBounds = new Rectangle(x, y, width, height);
            GraphicsPath rectanglePath = new GraphicsPath();
            rectanglePath.AddRectangle(expectedBounds);
            Assert.IsTrue(IsRectangleDrawn(bitmap, rectanglePath), "Rectangle is not drawn correctly.");
        }

        private bool IsRectangleDrawn(Bitmap bmp, GraphicsPath rectanglePath)
        {
            // Check if the rectangle is drawn in the bitmap
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Region region = new Region(rectanglePath);
                region.Intersect(g.Clip);
                return !region.IsEmpty(g);
            }
        }
    }
}
