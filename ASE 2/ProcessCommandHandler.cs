using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_2
{
    public class ProcessCommandHandler
    {
        private PrivateVariables pv;
        private PictureBox pictureBox;

        public ProcessCommandHandler(PrivateVariables pv)
        {
            this.pv = pv;
        }


        public void ProcessCommand(string command)
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
                            if (!isInsideWhileBlock || !pv.WhileConditionCheck)
                            {
                                HandleCircleCommand(commandParts);
                            }
                            else
                            {
                                commandsInsideWhile.Add(cmd);
                            }
                            break;

                        case "moveto":
                            if (!isInsideWhileBlock || !pv.WhileConditionCheck)
                            {
                                HandleMoveToCommand(commandParts);
                            }
                            else
                            {
                                commandsInsideWhile.Add(cmd);
                            }
                            break;

                        case "rect":
                            if (!isInsideWhileBlock || !pv.WhileConditionCheck)
                            {
                                HandleRectangleCommand(commandParts);
                            }
                            else
                            {
                                commandsInsideWhile.Add(cmd);
                            }
                            break;

                        case "square":
                            if (!isInsideWhileBlock || !pv.WhileConditionCheck)
                            {
                                HandleSquareCommand(commandParts);
                            }
                            else
                            {
                                commandsInsideWhile.Add(cmd);
                            }
                            break;

                        case "pen":
                            if (!isInsideWhileBlock || !pv.WhileConditionCheck)
                            {
                                HandleColorCommand(commandParts);
                            }
                            else
                            {
                                commandsInsideWhile.Add(cmd);
                            }
                            break;

                        case "while":
                            pv.whileCondition = cmd.Substring(5).Trim();
                            pv.WhileConditionCheck = pv.whileCommandHandler.HandleCondition(pv.whileCondition);
                            isInsideWhileBlock = true;
                            if (pv.WhileConditionCheck)
                                commandsInsideWhile.Clear();
                            break;

                        case "endwhile":
                            while (pv.WhileConditionCheck)
                            {
                                isInsideWhileBlock = false;
                                pv.WhileConditionCheck = false;

                                foreach (string commandInsideWhile in commandsInsideWhile)
                                {
                                    ProcessSingleCommand(commandInsideWhile);
                                }
                                pv.WhileConditionCheck = pv.whileCommandHandler.HandleCondition(pv.whileCondition);
                            }
                            break;

                        default:
                            if (isInsideWhileBlock && pv.WhileConditionCheck)
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

        public void ProcessSingleCommand(string cmd)
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

        public void HandleVariableDeclaration(string[] commandParts)
        {

            if (commandParts.Contains("="))
            {
                if (commandParts[0] == "var")
                {
                    string variableAssignmentCommand = string.Join(" ", commandParts.Skip(1));

                    pv.VariableProcessor.ProcessVariableAssignment(variableAssignmentCommand);
                }
                else
                {
                    string variableAssignmentCommand = string.Join(" ", commandParts);

                    pv.VariableProcessor.ProcessVariableAssignment(variableAssignmentCommand);

                }

            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Variable Declaration: " + string.Join(" ", commandParts));
            }
        }


        public void HandleCircleCommand(string[] commandParts)
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
                    pv.circleDrawer.DrawCircle(circleRadius, pv.x, pv.y);
                }

            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Circle Command: " + string.Join(" ", commandParts));
            }
        }

        public void HandleMoveToCommand(string[] commandParts)
        {
            if (commandParts.Length >= 3)
            {
                int newX, newY;

                if ((int.TryParse(commandParts[1], out newX) || TryGetVariableValue(commandParts[1], out newX)) &&
                    (int.TryParse(commandParts[2], out newY) || TryGetVariableValue(commandParts[2], out newY)))
                {

                    pv.x = newX;
                    pv.y = newY;
                }
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid MoveTo Command: " + string.Join(" ", commandParts));
            }
        }

        public void HandleRectangleCommand(string[] commandParts)
        {
            if (commandParts.Length >= 3)
            {
                int width, height;

                if ((int.TryParse(commandParts[1], out width) || TryGetVariableValue(commandParts[1], out width)) &&
                        (int.TryParse(commandParts[2], out height) || TryGetVariableValue(commandParts[2], out height)))
                {
                    pv.rectangleDrawer.DrawRectangle(width, height, pv.x, pv.y);
                }
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Rectangle Command: " + string.Join(" ", commandParts));
            }
        }

        public void HandleSquareCommand(string[] commandParts)
        {
            if (commandParts.Length >= 2)
            {
                int size;
                if (int.TryParse(commandParts[1], out size) || TryGetVariableValue(commandParts[1], out size))
                {
                    pv.squareDrawer.DrawSquare(size, pv.x, pv.y);
                }
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Square Command: " + string.Join(" ", commandParts));
            }
        }

        public void HandleColorCommand(string[] commandParts)
        {
            if (commandParts.Length >= 2)
            {
                string colorName = commandParts[1];
                try
                {
                    pv.pen.Color = ColorHandler.ParseColor(colorName);
                }
                catch (ArgumentException ex)
                {
                    HelperFunctions.DisplayMessage(pictureBox, ex.Message);
                }
            }
            else
            {
                HelperFunctions.DisplayMessage(pictureBox, "Invalid Color Command Format: " + string.Join(" ", commandParts));
            }
        }

        public bool TryGetVariableValue(string variableName, out int variableValue)
        {
            variableValue = pv.VariableProcessor.GetVariableValue(variableName);
            return variableValue > 0;
        }

    }

}