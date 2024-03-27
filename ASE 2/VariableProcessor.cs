using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;

namespace ASE_2
{
    public class VariableProcessor
    {
        private static VariableProcessor instance;
        private Dictionary<string, int> dataStorage = new Dictionary<string, int>();

        public VariableProcessor() { }

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

        public bool IsVariableExisting(string variableAlias)
        {
            return dataStorage.ContainsKey(variableAlias);
        }

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

        public void AssignVariableValue(string variableAlias, int value)
        {
            dataStorage[variableAlias] = value;
        }

        public void ClearDataStorage()
        {
            dataStorage.Clear();
        }

        public IEnumerable<string> GetAllVariableAliases()
        {
            return dataStorage.Keys;
        }

        internal void ProcessVariableAssignment(string command)
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

        internal int EvaluateExpression(string expression)
        {
            Dictionary<string, int> variableValues = new Dictionary<string, int>();

            foreach (var variableAlias in GetAllVariableAliases())
            {
                variableValues[variableAlias] = GetVariableValue(variableAlias);
            }

            return ProcessRecursiveExpression(expression, variableValues);
        }

        internal int ProcessRecursiveExpression(string expression, Dictionary<string, int> variableValues)
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
