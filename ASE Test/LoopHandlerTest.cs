using ASE_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASE_Test
{
    /// <summary>
    /// Unit tests for the LoopHandler class.
    /// </summary>
    [TestClass]
    public class LoopHandlerTests
    {
        /// <summary>
        /// Test to verify evaluation of a less than condition.
        /// </summary>
        [TestMethod]
        public void EvaluatesLessThanCondition()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            LoopHandler loopHandler = new LoopHandler(variableProcessor);
            variableProcessor.AssignVariableValue("x", 5);

            // Act
            bool result = loopHandler.HandleCondition("x < 10");

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test to verify evaluation of a greater than condition.
        /// </summary>
        [TestMethod]
        public void EvaluatesGreaterThanCondition()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            LoopHandler loopHandler = new LoopHandler(variableProcessor);
            variableProcessor.AssignVariableValue("x", 5);

            // Act
            bool result = loopHandler.HandleCondition("x > 3");

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test to verify evaluation of an equal to condition.
        /// </summary>
        [TestMethod]
        public void EvaluatesEqualToCondition()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            LoopHandler loopHandler = new LoopHandler(variableProcessor);
            variableProcessor.AssignVariableValue("x", 5);

            // Act
            bool result = loopHandler.HandleCondition("x == 5");

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test to verify that an exception is thrown for an invalid condition.
        /// </summary>
        [TestMethod]
        public void ThrowsExceptionForInvalid()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            LoopHandler loopHandler = new LoopHandler(variableProcessor);
            variableProcessor.AssignVariableValue("x", 5);

            // Act and assert
            Assert.ThrowsException<ArgumentException>(() => loopHandler.Evaluate("x invalidcondition"));
        }

        /// <summary>
        /// Test to verify that an exception is thrown for a non-numeric value in the condition.
        /// </summary>
        [TestMethod]
        public void ThrowsExceptionForNonNumeric()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            LoopHandler loopHandler = new LoopHandler(variableProcessor);
            variableProcessor.AssignVariableValue("x", 5);

            // Act and assert
            Assert.ThrowsException<ArgumentException>(() => loopHandler.Evaluate("x < abc"));
        }
    }
}
