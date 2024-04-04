using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;

namespace ASE_2
{
    /// <summary>
    /// A class for processing variables and evaluating expressions.
    /// </summary>
    public class VariableProcessor
    {
        private static VariableProcessor instance;
        private Dictionary<string, int> dataStorage = new Dictionary<string, int>();

        /// <summary>
        /// Constructs a new instance of the VariableProcessor class.
        /// </summary>
        public VariableProcessor() { }

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
        public bool IsVariableExisting(string variableAlias)
        {
            return dataStorage.ContainsKey(variableAlias);
        }

        /// <summary>
        /// Gets the value of the variable with the specified alias.
        /// </summary>
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
        public void AssignVariableValue(string variableAlias, int value)
        {
            dataStorage[variableAlias] = value;
        }

        /// <summary>
        /// Clears all data storage.
        /// </summary>
        public void ClearDataStorage()
        {
            dataStorage.Clear();
        }

        /// <summary>
        /// Retrieves all variable aliases.
        /// </summary>
        public IEnumerable<string> GetAllVariableAliases()
        {
            return dataStorage.Keys;
        }

        /// <summary>
        /// Processes a variable assignment command.
        /// </summary>
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
        /// Evaluates an arithmetic expression.
        /// </summary>
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
        /// Recursively processes an arithmetic expression.
        /// </summary>
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
