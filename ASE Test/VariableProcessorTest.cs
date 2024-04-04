﻿using ASE_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Test
{
    [TestClass]
    public class VariableProcessorTests
    {
        [TestMethod]
        public void ExistsForExistingVariable()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            variableProcessor.AssignVariableValue("x", 10);

            // Act
            bool result = variableProcessor.IsVariableExisting("x");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetValueForExistingVariable()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            variableProcessor.AssignVariableValue("y", 20);

            // Act
            int value = variableProcessor.GetVariableValue("y");

            // Assert
            Assert.AreEqual(20, value);
        }

        [TestMethod]
        public void AssignsValueToVariable()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;

            // Act
            variableProcessor.AssignVariableValue("z", 30);

            // Assert
            Assert.IsTrue(variableProcessor.IsVariableExisting("z"));
            Assert.AreEqual(30, variableProcessor.GetVariableValue("z"));
        }

        [TestMethod]
        public void ClearsAllVariables()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            variableProcessor.AssignVariableValue("a", 10);
            variableProcessor.AssignVariableValue("b", 20);

            // Act
            variableProcessor.ClearDataStorage();

            // Assert
            Assert.IsFalse(variableProcessor.IsVariableExisting("a"));
            Assert.IsFalse(variableProcessor.IsVariableExisting("b"));
        }


        [TestMethod]
        public void ProcessAssignment()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;

            // Act
            variableProcessor.ProcessVariableAssignment("x = 10");

            // Assert
            Assert.IsTrue(variableProcessor.IsVariableExisting("x"));
            Assert.AreEqual(10, variableProcessor.GetVariableValue("x"));
        }

        [TestMethod]
        public void EvaluateWithVariables()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            variableProcessor.AssignVariableValue("a", 5);
            variableProcessor.AssignVariableValue("b", 7);

            // Act
            int result = variableProcessor.EvaluateExpression("a + b");

            // Assert
            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void ProcessRecursiveExpression()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            variableProcessor.AssignVariableValue("x", 3);
            variableProcessor.AssignVariableValue("y", 2);

            // Act
            int result = variableProcessor.ProcessRecursiveExpression("x * y + 5", variableProcessor.GetAllVariableAliases().ToDictionary(alias => alias, alias => variableProcessor.GetVariableValue(alias)));

            // Assert
            Assert.AreEqual(11, result);
        }
    }
}