using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_2
{
    public class ColorHandler
    {
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
