using ASE_2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection.Emit;


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
        private readonly VariableProcessor VariableProcessor = VariableProcessor.Singleton;
        private bool IsInsideWhileBlock = false;
        private bool WhileConditionCheck = false;
        private readonly LoopHandler whileCommandHandler;
        private string whileCondition = "";

        public Form1()
        {
            InitializeComponent();
            g = pictureBox.CreateGraphics();
            pen = new Pen(Color.Black, 2);
            brush = new SolidBrush(Color.Red);
            circleDrawer = new CircleDrawer(g, pen, brush);
            rectangleDrawer = new RectangleDrawer(g, pen, brush);
            squareDrawer = new SquareDrawer(g, pen);
            whileCommandHandler = new LoopHandler(VariableProcessor);
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

            IsInsideWhileBlock = false;
            WhileConditionCheck = false;
            whileCondition = "";
    }

        private void ProcessCommand(string command)
        {
            string[] commands = command.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            int lineNumber = 1;
            int totalCommands = commands.Length;
            bool isInsideWhileBlock = false;
            List<string> commandsInsideWhile = new List<string>(); // To store commands inside the while loop

            while (lineNumber <= totalCommands)
            {
                string cmd = commands[lineNumber - 1];
                string[] commandParts = cmd.Split(' ');

                if (commandParts.Length >= 1)
                {
                    string action = commandParts[0].ToLower();

                    switch (action)
                    {
                        case "var":
                            HandleVariableDeclaration(commandParts);
                            break;

                        case "circle":
                            if (!isInsideWhileBlock || !WhileConditionCheck)
                            {
                                HandleCircleCommand(commandParts);
                            }
                            else
                            {
                                commandsInsideWhile.Add(cmd);
                            }
                            break;

                        case "moveto":
                            if (!isInsideWhileBlock || !WhileConditionCheck)
                            {
                                HandleMoveToCommand(commandParts);
                            }
                            else
                            {
                                commandsInsideWhile.Add(cmd);
                            }
                            break;

                        case "rect":
                            if (!isInsideWhileBlock || !WhileConditionCheck)
                            {
                                HandleRectangleCommand(commandParts);
                            }
                            else
                            {
                                commandsInsideWhile.Add(cmd);
                            }
                            break;

                        case "square":
                            if (!isInsideWhileBlock || !WhileConditionCheck)
                            {
                                HandleSquareCommand(commandParts);
                            }
                            else
                            {
                                commandsInsideWhile.Add(cmd);
                            }
                            break;

                        case "pen":
                            if (!isInsideWhileBlock || !WhileConditionCheck)
                            {
                                HandleColorCommand(commandParts);
                            }
                            else
                            {
                                commandsInsideWhile.Add(cmd);
                            }
                            break;

                        case "while":
                            whileCondition = cmd.Substring(5).Trim();
                            WhileConditionCheck = whileCommandHandler.HandleCondition(whileCondition);
                            isInsideWhileBlock = true;
                            if (WhileConditionCheck)
                                commandsInsideWhile.Clear(); 
                            break;

                        case "endwhile":
                            while (WhileConditionCheck)
                            {
                                isInsideWhileBlock = false; 
                                WhileConditionCheck = false;

                                foreach (string commandInsideWhile in commandsInsideWhile)
                                {
                                    ProcessSingleCommand(commandInsideWhile);
                                }
                                WhileConditionCheck = whileCommandHandler.HandleCondition(whileCondition);
                            }
                            break;

                        default:
                            if (isInsideWhileBlock && WhileConditionCheck)
                            {
                                commandsInsideWhile.Add(cmd); 
                            }
                            else
                            {
                                MessageBox.Show(commandParts[1]);
                                if (commandParts[1].Contains("="))
                                {
                                    HandleVariableDeclaration(commandParts);
                                }
                                else
                                {
                                    HelperFunctions.DisplayMessage(pictureBox, "Invalid hghg: " + cmd);
                                }
                            }
                            break;
                    }
                }
                else
                {
                    HelperFunctions.DisplayMessage(pictureBox, "Invalid Command Format: " + cmd);
                }

                lineNumber++;
            }
        }

        private void ProcessSingleCommand(string cmd)
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
                        if (commandParts[1].Contains("="))
                        {
                            HandleVariableDeclaration(commandParts);
                        }
                        else
                        {
                            HelperFunctions.DisplayMessage(pictureBox, "Invalid hghg: " + cmd);
                        }
                        break;
                }
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Command Format: " + cmd);
            }
        }

        private void HandleVariableDeclaration(string[] commandParts)
        {

            if (commandParts.Contains("="))
            {
                if (commandParts[0] == "var")
                {
                    string variableAssignmentCommand = string.Join(" ", commandParts.Skip(1));

                    VariableProcessor.ProcessVariableAssignment(variableAssignmentCommand);
                }
                else
                {
                    string variableAssignmentCommand = string.Join(" ", commandParts);

                    VariableProcessor.ProcessVariableAssignment(variableAssignmentCommand);

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
                int circleRadius;

                if (int.TryParse(commandParts[1], out circleRadius) || TryGetVariableValue(commandParts[1], out circleRadius))
                {
                    // Validate radius
                    if (circleRadius <= 0)
                    {
                        throw new ArgumentException("circle radius value should be positive");
                    }
                    circleDrawer.DrawCircle(circleRadius, x, y);
                }

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
                int newX, newY;

                if ((int.TryParse(commandParts[1], out newX) || TryGetVariableValue(commandParts[1], out newX)) &&
                    (int.TryParse(commandParts[2], out newY) || TryGetVariableValue(commandParts[2], out newY)))
                {

                    x = newX;
                    y = newY;
                }
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
                int width, height;

                if ((int.TryParse(commandParts[1], out width) || TryGetVariableValue(commandParts[1], out width)) &&
                        (int.TryParse(commandParts[2], out height) || TryGetVariableValue(commandParts[2], out height)))
                {
                    rectangleDrawer.DrawRectangle(width, height, x, y);
                }
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
                int size;
                if (int.TryParse(commandParts[1], out size) || TryGetVariableValue(commandParts[1], out size))
                {
                    squareDrawer.DrawSquare(size, x, y);
                }
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

        private bool TryGetVariableValue(string variableName, out int variableValue)
        {
            variableValue = VariableProcessor.GetVariableValue(variableName);
            return variableValue > 0;
        }
    }
}