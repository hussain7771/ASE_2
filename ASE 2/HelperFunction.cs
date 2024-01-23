using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_2
{
    public class HelperFunction
    {
        public static void DisplayMessage(PictureBox pictureBox, string errorMessage)
        {
            // Create a new bitmap for the PictureBox
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);

            // Create a graphics object from the bitmap
            using (Graphics g = Graphics.FromImage(bmp))
            {
                // Set the font and brush for the text
                Font font = new Font("Arial", 12);
                SolidBrush brush = new SolidBrush(Color.Red);

                // Set the position where you want to display the text on the image
                Point textPosition = new Point(10, 10);

                // Draw the text on the image
                g.DrawString(errorMessage, font, brush, textPosition);
            }

            // Display the modified image with the message in the PictureBox
            pictureBox.Image = bmp;
        }
    }
}
