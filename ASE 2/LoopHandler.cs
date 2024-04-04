using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_2
{
    /// <summary>
    /// Handles looping conditions and evaluates them.
    /// </summary>
    public class LoopHandler
    {
        private readonly VariableProcessor VariableProcessor;

        /// <summary>
        /// Initializes a new instance of the LoopHandler class with the specified VariableProcessor.
        /// </summary>
        /// <param name="variableProcessor">The VariableProcessor instance to use for variable evaluation.</param>
        public LoopHandler(VariableProcessor variableProcessor)
        {
            this.VariableProcessor = variableProcessor;
        }

        /// <summary>
        /// Handles the given loop condition.
        /// </summary>
        /// <param name="condition">The loop condition to handle.</param>
        /// <returns>True if the condition is met, otherwise false.</returns>
        public bool HandleCondition(string condition)
        {
            condition = condition.Trim();
            return Evaluate(condition);
        }

        /// <summary>
        /// Evaluates the given loop condition.
        /// </summary>
        /// <param name="condition">The loop condition to evaluate.</param>
        /// <returns>True if the condition is met, otherwise false.</returns>
        public bool Evaluate(string condition)
        {
            var parts = condition.Split(new[] { '<', '>', '=' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                throw new ArgumentException("Invalid Condition");
            }

            string variableName = parts[0].Trim();
            string comparisonValueString = parts[1].Trim();

            if (!int.TryParse(comparisonValueString, out int comparisonValue))
            {
                throw new ArgumentException("Numeric value required");
            }

            int variableValue = VariableProcessor.GetVariableValue(variableName);

            return condition.Contains("<") ? variableValue < comparisonValue :
                       condition.Contains(">") ? variableValue > comparisonValue :
                                                  variableValue == comparisonValue;
        }
    }
}
