using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASE_2
{
    /// <summary>
    /// Handles the processing of commands and executes them.
    /// </summary>
    public class ProcessCommandHandler
    {
        private PrivateVariables pv;
        private PictureBox pictureBox;

        /// <summary>
        /// Initializes a new instance of the ProcessCommandHandler class with the specified PrivateVariables.
        /// </summary>
        /// <param name="pv">The PrivateVariables instance to use for command processing.</param>
        public ProcessCommandHandler(PrivateVariables pv)
        {
            this.pv = pv;
        }

        /// <summary>
        /// Processes the given command string.
        /// </summary>
        /// <param name="command">The command string to process.</param>
        public void ProcessCommand(string command)
        {
            // Method implementation omitted for brevity
        }

        /// <summary>
        /// Processes a single command string.
        /// </summary>
        /// <param name="cmd">The command string to process.</param>
        public void ProcessSingleCommand(string cmd)
        {
            // Method implementation omitted for brevity
        }

        // Other methods omitted for brevity

        /// <summary>
        /// Tries to retrieve the value of a variable by its name.
        /// </summary>
        /// <param name="variableName">The name of the variable to retrieve.</param>
        /// <param name="variableValue">The value of the variable, if found.</param>
        /// <returns>True if the variable value was successfully retrieved, otherwise false.</returns>
        public bool TryGetVariableValue(string variableName, out int variableValue)
        {
            variableValue = pv.VariableProcessor.GetVariableValue(variableName);
            return variableValue > 0;
        }
    }
}
