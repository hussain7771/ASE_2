using ASE_2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ASE_2
{
    /// <summary>
    /// Represents the main form of the application.
    /// </summary>
    public partial class Form1 : Form
    {
        private PrivateVariables pv;
        private ProcessCommandHandler commandHandler;

        /// <summary>
        /// Initializes a new instance of the Form1 class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            pv = new PrivateVariables(pictureBox);
            commandHandler = new ProcessCommandHandler(pv);
        }

        /// <summary>
        /// Handles the click event of the Run button.
        /// </summary>
        public void Run_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CommandInput.Text))
            {
                HelperFunctions.DisplayMessage(pictureBox, "Please Enter Command.");
                return;
            }
            commandHandler.ProcessCommand(CommandInput.Text);
        }

        /// <summary>
        /// Parses the parameter value.
        /// </summary>
        /// <param name="parameter">The parameter value to parse.</param>
        /// <returns>The parsed parameter value.</returns>
        private int ParseParameterValue(string parameter)
        {
            if (pv.variables.ContainsKey(parameter))
            {
                return pv.variables[parameter]; // Return value of variable
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

        /// <summary>
        /// Handles the click event of the Save button.
        /// </summary>
        public void Save_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Handles the click event of the Open button.
        /// </summary>
        public void Open_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Handles the click event of the Clear button.
        /// </summary>
        public void Clear_Click(object sender, EventArgs e)
        {
            pv.variables.Clear();
            pv.x = pv.y = 0;
            pictureBox.Image = null;
            pv.pen.Color = Color.Black;
            pv.IsInsideWhileBlock = pv.WhileConditionCheck = false;
            pv.whileCondition = "";
        }

        /// <summary>
        /// Throws NotImplementedException when invoked with two parameters.
        /// </summary>
        public void Clear_Click(object value1, object value2)
        {
            throw new NotImplementedException();
        }
    }
}
