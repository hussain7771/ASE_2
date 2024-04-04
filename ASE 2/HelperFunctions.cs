using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_2
{
    /// <summary>
    /// Provides helper functions for the application.
    /// </summary>
    public class HelperFunctions
    {
        /// <summary>
        /// Displays an error message on a PictureBox.
        /// </summary>
        /// <param name="pictureBox">The PictureBox to display the message on.</param>
        /// <param name="errorMessage">The error message to display.</param>
        public static void DisplayMessage(PictureBox pictureBox, string errorMessage)
        {
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                Font font = new Font("Arial", 12);
                SolidBrush brush = new SolidBrush(Color.Red);
                Point textPosition = new Point(10, 10);
                g.DrawString(errorMessage, font, brush, textPosition);
            }

            pictureBox.Image = bmp;
        }
    }
}
