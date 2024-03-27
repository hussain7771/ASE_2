using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_2
{
    public class LoopHandler
    {
        private readonly VariableProcessor VariableProcessor;

        public LoopHandler(VariableProcessor VariableProcessor)
        {
            this.VariableProcessor = VariableProcessor;
        }

        public bool HandleCondition(string condition)
        {
            condition = condition.Trim();
            return Evaluate(condition);
        }

        public bool Evaluate(string condition)
        {
            var parts = condition.Split(new[] { '<', '>', '=' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                throw new ArgumentException("Invalid Conditin");
            }

            string variableName = parts[0].Trim();
            string comparisonValueString = parts[1].Trim();

            if (!int.TryParse(comparisonValueString, out int comparisonValue))
            {
                throw new ArgumentException("numeric value required");
            }

            int variableValue = VariableProcessor.GetVariableValue(variableName);

            return condition.Contains("<") ? variableValue < comparisonValue :
                       condition.Contains(">") ? variableValue > comparisonValue :
                                                  variableValue == comparisonValue;
        }
    }
}
