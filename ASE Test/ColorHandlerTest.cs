﻿using ASE_2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Test
{
    [TestClass]
    public class ColorHandlerTests
    {
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