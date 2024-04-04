using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_2;

namespace ASE_2_Test
{
    [TestClass]
    public class CircleDrawerTests
    {
        [TestMethod]
        public void DrawCircle_PositionLessThanCondition()
        {
            // Arrange
            Bitmap bitmap = new Bitmap(800, 600);
            Graphics graphics = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Black);
            Brush brush = Brushes.Red;
            CircleDrawer circleDrawer = new CircleDrawer(graphics, pen, brush);
            int x = 5; // x-coordinate less than 10
            int y = 100;
            int radius = 50;

            // Act
            circleDrawer.DrawCircle(radius, x, y);

            // Assert
            // Check if the pixel at the center of the circle is affected
            Color centerPixelColor = bitmap.GetPixel(x, y);
            Assert.AreNotEqual(Color.Transparent, centerPixelColor); // Assuming the circle is filled and not transparent
        }
    }
}
