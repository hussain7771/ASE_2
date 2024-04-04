using ASE_2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASE_Test
{
    /// <summary>
    /// Unit tests for the ColorHandler class.
    /// </summary>
    [TestClass]
    public class ColorHandlerTests
    {
        /// <summary>
        /// Test to verify parsing of valid color names.
        /// </summary>
        [TestMethod]
        public void ColorTest()
        {
            // Arrange
            string[] validColorNames = { "red", "green", "blue", "yellow", "purple" };

            // Act and assert
            foreach (var colorName in validColorNames)
            {
                Color color = ColorHandler.ParseColor(colorName);
                Assert.IsNotNull(color);
                // You can add more specific assertions for each color if needed
            }
        }

        /// <summary>
        /// Test to verify handling of an invalid color name.
        /// </summary>
        [TestMethod]
        public void ProcessAssignment()
        {
            // Arrange
            string invalidColorName = "invalid";

            // Act and assert
            Assert.ThrowsException<ArgumentException>(() => ColorHandler.ParseColor(invalidColorName));
        }
    }
}
