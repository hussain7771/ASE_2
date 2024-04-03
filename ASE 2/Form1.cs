using ASE_2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ASE_2
{
    public partial class Form1 : Form
    {
        private PrivateVariables pv;
        private ProcessCommandHandler commandHandler;

        public Form1()
        {
            InitializeComponent();
            pv = new PrivateVariables(pictureBox);
            commandHandler = new ProcessCommandHandler(pv);
        }

        public void Run_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CommandInput.Text))
            {
                HelperFunctions.DisplayMessage(pictureBox, "Please Enter Command.");
                return;
            }
            commandHandler.ProcessCommand(CommandInput.Text);
        }

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

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

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

        public void Clear_Click(object sender, EventArgs e)
        {
            pv.variables.Clear();
            pv.x = pv.y = 0;
            pictureBox.Image = null;
            pv.pen.Color = Color.Black;
            pv.IsInsideWhileBlock = pv.WhileConditionCheck = false;
            pv.whileCondition = "";
        }

        public void Clear_Click(object value1, object value2)
        {
            throw new NotImplementedException();
        }
    }
}