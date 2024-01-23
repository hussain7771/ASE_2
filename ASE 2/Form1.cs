using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_2
{
    public partial class Form1 : Form
    {
        private int x = 0, y = 0;
        private Graphics g;
        private Pen pen;
        private Brush brush;
        private CircleDrawer circleDrawer;
        private RectangleDrawer rectangleDrawer;

        public Form1()
        {
            InitializeComponent();
            g = pictureBox.CreateGraphics();
            pen = new Pen(Color.Blue, 2);
            brush = new SolidBrush(Color.Red);
            circleDrawer = new CircleDrawer(g, pen, brush);
            rectangleDrawer = new RectangleDrawer(g, pen, brush);
        }

        private void Run_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CommandInput.Text))
            {
                HelperFunctions.DisplayMessage(pictureBox, "Please Enter Command.");
                return;
            }
            ProcessCommand(CommandInput.Text);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var extension = System.IO.Path.GetExtension(saveFileDialog.FileName);
                if (extension.ToLower() == ".txt")
                    CommandInput.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.PlainText);
                else
                    CommandInput.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog opentext = new OpenFileDialog();
            if (opentext.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = opentext.FileName;
                CommandInput.LoadFile(selectedFileName, RichTextBoxStreamType.PlainText);
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Error Occurred");
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {

            CommandInput.Text = "";
            pictureBox.Image = null;
        }

        private void ProcessCommand(string command)
        {
            string[] commandParts = command.Split(' ');

            if (commandParts.Length >= 2)
            {
                string action = commandParts[0].ToLower();

                switch (action)
                {
                    case "circle":
                        HandleCircleCommand(commandParts);
                        break;

                    case "moveto":
                        HandleMoveToCommand(commandParts);
                        break;

                    case "rect":
                        HandleRectangleCommand(commandParts);
                        break;

                    default:
                        HelperFunctions.DisplayMessage(pictureBox, "Invalid Command.");
                        break;
                }
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Command Format.");
            }
        }

        private void HandleCircleCommand(string[] commandParts)
        {
            int radius;
            if (int.TryParse(commandParts[1], out radius))
            {
                circleDrawer.DrawCircle(radius, x, y);
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Radius.");
            }
        }

        private void HandleMoveToCommand(string[] commandParts)
        {
            int newX, newY;

            if (int.TryParse(commandParts[1], out newX) && int.TryParse(commandParts[2], out newY))
            {
                x += newX;
                y += newY;
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Coordinates.");
            }
        }

        private void HandleRectangleCommand(string[] commandParts)
        {
            int width, height;

            if (int.TryParse(commandParts[1], out width) && int.TryParse(commandParts[2], out height))
            {
                rectangleDrawer.DrawRectangle(width, height, x, y);
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Rectangle Dimensions.");
            }
        }
    }
}
