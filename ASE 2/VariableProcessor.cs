using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ASE_2
{
    /// <summary>
    /// Provides functionality to manage variables and evaluate expressions.
    /// </summary>
    public class VariableProcessor
    {
        private static VariableProcessor instance;
        private Dictionary<string, int> dataStorage = new Dictionary<string, int>();

        /// <summary>
        /// Initializes a new instance of the VariableProcessor class.
        /// </summary>
        private VariableProcessor() { }

        /// <summary>
        /// Gets the singleton instance of the VariableProcessor class.
        /// </summary>
        public static VariableProcessor Singleton
        {
            get
            {
                if (instance == null)
                {
                    instance = new VariableProcessor();
                }
                return instance;
            }
        }

        /// <summary>
        /// Checks if a variable with the specified alias exists.
        /// </summary>
        /// <param name="variableAlias">The alias of the variable to check.</param>
        /// <returns>True if the variable exists; otherwise, false.</returns>
        public bool IsVariableExisting(string variableAlias)
        {
            return dataStorage.ContainsKey(variableAlias);
        }

        /// <summary>
        /// Gets the value of the variable with the specified alias.
        /// </summary>
        /// <param name="variableAlias">The alias of the variable.</param>
        /// <returns>The value of the variable.</returns>
        public int GetVariableValue(string variableAlias)
        {
            if (dataStorage.TryGetValue(variableAlias, out int value))
            {
                return value;
            }
            else
            {
                throw new ArgumentException($"Variable '{variableAlias}' not found.");
            }
        }

        /// <summary>
        /// Assigns a value to the variable with the specified alias.
        /// </summary>
        /// <param name="variableAlias">The alias of the variable.</param>
        /// <param name="value">The value to assign to the variable.</param>
        public void AssignVariableValue(string variableAlias, int value)
        {
            dataStorage[variableAlias] = value;
        }

        /// <summary>
        /// Clears all variables from the data storage.
        /// </summary>
        public void ClearDataStorage()
        {
            dataStorage.Clear();
        }

        /// <summary>
        /// Retrieves all variable aliases stored in the data storage.
        /// </summary>
        /// <returns>An enumerable collection of variable aliases.</returns>
        public IEnumerable<string> GetAllVariableAliases()
        {
            return dataStorage.Keys;
        }

        /// <summary>
        /// Processes a variable assignment command and updates the data storage accordingly.
        /// </summary>
        /// <param name="command">The variable assignment command.</param>
        public void ProcessVariableAssignment(string command)
        {
            string[] assignmentParts = command.Split('=').Select(part => part.Trim()).ToArray();

            if (assignmentParts.Length == 2)
            {
                string variableAlias = assignmentParts[0];
                string expression = assignmentParts[1];
                if (IsVariableExisting(variableAlias))
                {
                    int result = EvaluateExpression(expression);
                    AssignVariableValue(variableAlias, result);
                }
                else
                {
                    int result = EvaluateExpression(expression);
                    AssignVariableValue(variableAlias, result);
                }
            }
            else
            {
                throw new ArgumentException("Valid variable assignment command required.");
            }
        }

        /// <summary>
        /// Evaluates an arithmetic expression and returns the result.
        /// </summary>
        /// <param name="expression">The arithmetic expression to evaluate.</param>
        /// <returns>The result of the evaluation.</returns>
        public int EvaluateExpression(string expression)
        {
            Dictionary<string, int> variableValues = new Dictionary<string, int>();

            foreach (var variableAlias in GetAllVariableAliases())
            {
                variableValues[variableAlias] = GetVariableValue(variableAlias);
            }

            return ProcessRecursiveExpression(expression, variableValues);
        }

        /// <summary>
        /// Recursively processes an arithmetic expression by substituting variable values and evaluating the result.
        /// </summary>
        /// <param name="expression">The arithmetic expression to process.</param>
        /// <param name="variableValues">A dictionary containing variable aliases and their corresponding values.</param>
        /// <returns>The result of the expression evaluation.</returns>
        public int ProcessRecursiveExpression(string expression, Dictionary<string, int> variableValues)
        {
            if (int.TryParse(expression, out int value))
            {
                return value;
            }

            foreach (var variableAlias in variableValues.Keys)
            {
                string variableExpression = $"{variableAlias}";

                if (expression.Contains(variableExpression))
                {
                    expression = expression.Replace(variableExpression, variableValues[variableAlias].ToString());
                }
            }

            DataTable table = new DataTable();
            var result = table.Compute(expression, "");
            return Convert.ToInt32(result);
        }
    }
}
