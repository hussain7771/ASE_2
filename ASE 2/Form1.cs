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
        private SquareDrawer squareDrawer;
        private Dictionary<string, int> variables = new Dictionary<string, int>();


        public Form1()
        {
            InitializeComponent();
            g = pictureBox.CreateGraphics();
            pen = new Pen(Color.Black, 2);
            brush = new SolidBrush(Color.Red);
            circleDrawer = new CircleDrawer(g, pen, brush);
            rectangleDrawer = new RectangleDrawer(g, pen, brush);
            squareDrawer = new SquareDrawer(g, pen);

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

        private int ParseParameterValue(string parameter)
        {
            if (variables.ContainsKey(parameter))
            {
                return variables[parameter]; // Return value of variable
            }
            else
            {
                int value;
                if (int.TryParse(parameter, out value))
                {
                    return value; // Return numerical value
                }
                else
                {
                    HelperFunctions.DisplayMessage(pictureBox, "Invalid Parameter Value: " + parameter);
                    return 0; // Default value if parsing fails
                }
            }
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

            // Clear variables dictionary
            variables.Clear();

            // Reset drawing position (x and y)
            x = 0;
            y = 0;

            // Clear picture box
            pictureBox.Image = null;

            // Reset pen color to black
            pen.Color = Color.Black;
        }

        private void ProcessCommand(string command)
        {
            string[] commands = command.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string cmd in commands)
            {
                string[] commandParts = cmd.Split(' ');

                if (commandParts.Length >= 2)
                {
                    string action = commandParts[0].ToLower();

                    switch (action)
                    {
                        case "var":
                            HandleVariableDeclaration(commandParts);
                            break;

                        case "circle":
                            HandleCircleCommand(commandParts);
                            break;

                        case "moveto":
                            HandleMoveToCommand(commandParts);
                            break;

                        case "rect":
                            HandleRectangleCommand(commandParts);
                            break;

                        case "square":
                            HandleSquareCommand(commandParts);
                            break;

                        case "pen":
                            HandleColorCommand(commandParts);
                            break;

                        default:
                            HelperFunctions.DisplayMessage(pictureBox, "Invalid Command: " + cmd);
                            break;
                    }
                }
                else
                {
                    HelperFunctions.DisplayMessage(pictureBox, "Invalid Command Format: " + cmd);
                }
            }
        }

        private void HandleVariableDeclaration(string[] commandParts)
        {
            if (commandParts.Length >= 4 && commandParts[2] == "=")
            {
                string variableName = commandParts[1];
                int variableValue = ParseParameterValue(commandParts[3]);

                if (variables.ContainsKey(variableName))
                {
                    variables[variableName] = variableValue; // Update existing variable
                }
                else
                {
                    variables.Add(variableName, variableValue); // Add new variable
                }
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Variable Declaration: " + string.Join(" ", commandParts));
            }
        }


        private void HandleCircleCommand(string[] commandParts)
        {
            if (commandParts.Length >= 2)
            {
                int radius = ParseParameterValue(commandParts[1]);
                circleDrawer.DrawCircle(radius, x, y);
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Circle Command: " + string.Join(" ", commandParts));
            }
        }

        private void HandleMoveToCommand(string[] commandParts)
        {
            if (commandParts.Length >= 3)
            {
                int newX = ParseParameterValue(commandParts[1]);
                int newY = ParseParameterValue(commandParts[2]);
                x = newX;
                y = newY;
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid MoveTo Command: " + string.Join(" ", commandParts));
            }
        }

        private void HandleRectangleCommand(string[] commandParts)
        {
            if (commandParts.Length >= 3)
            {
                int width = ParseParameterValue(commandParts[1]);
                int height = ParseParameterValue(commandParts[2]);
                rectangleDrawer.DrawRectangle(width, height, x, y);
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Rectangle Command: " + string.Join(" ", commandParts));
            }
        }

        private void HandleSquareCommand(string[] commandParts)
        {
            if (commandParts.Length >= 2)
            {
                int size = ParseParameterValue(commandParts[1]);
                squareDrawer.DrawSquare(size, x, y);
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Square Command: " + string.Join(" ", commandParts));
            }
        }

        private void HandleColorCommand(string[] commandParts)
        {
            if (commandParts.Length >= 2)
            {
                string colorName = commandParts[1].ToLower();
                Color color;

                switch (colorName)
                {
                    case "red":
                        color = Color.Red;
                        break;

                    case "green":
                        color = Color.Green;
                        break;

                    case "blue":
                        color = Color.Blue;
                        break;

                    case "yellow":
                        color = Color.Yellow;
                        break;

                    case "purple":
                        color = Color.Purple;
                        break;

                    default:
                        HelperFunctions.DisplayMessage(pictureBox, "Invalid Color Name: " + colorName);
                        return;
                }

                pen.Color = color;
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Color Command Format: " + string.Join(" ", commandParts));
            }
        }
    }
}