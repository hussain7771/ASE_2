using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_2;
using System.Drawing.Drawing2D;

namespace ASE_Test
{
    [TestClass]
    public class SquareDrawerTests
    {
       
        
        [TestMethod]
        public void DrawSquare_ValidParameters()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(800, 600);
            Graphics graphics = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Black);
            SquareDrawer squareDrawer = new SquareDrawer(graphics, pen);
            int size = 50;
            int x = 100;
            int y = 100;

            // Act
            squareDrawer.DrawSquare(size, x, y);

            // Assert
            Rectangle expectedBounds = new Rectangle(x, y, size, size);
            GraphicsPath squarePath = new GraphicsPath();
            squarePath.AddRectangle(expectedBounds);
            Assert.IsTrue(IsSquareDrawn(bitmap, squarePath), "Square is not drawn correctly.");
        }

        private bool IsSquareDrawn(Bitmap bmp, GraphicsPath squarePath)
        {
            // Check if the square is drawn in the bitmap
            using (Graphics g = Graphics.FromImage(bmp))
            {
                Region region = new Region(squarePath);
                region.Intersect(g.Clip);
                return !region.IsEmpty(g);
            }
        }
    }
    
}
