using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_2
{
    /// <summary>
    /// A class for handling color parsing in the ASE application.
    /// </summary>
    public class ColorHandler
    {
        /// <summary>
        /// Parses a color name string and returns the corresponding Color object.
        /// </summary>
        /// <param name="colorName">The name of the color to parse.</param>
        /// <returns>The Color object corresponding to the specified color name.</returns>
        public static Color ParseColor(string colorName)
        {
            colorName = colorName.ToLower();
            switch (colorName)
            {
                case "red":
                    return Color.Red;
                case "green":
                    return Color.Green;
                case "blue":
                    return Color.Blue;
                case "yellow":
                    return Color.Yellow;
                case "purple":
                    return Color.Purple;
                default:
                    throw new ArgumentException("Invalid color name: " + colorName);
            }
        }
    }
}
