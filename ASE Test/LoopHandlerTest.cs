using ASE_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASE_Test
{
    [TestClass]
    public class LoopHandlerTests
    {
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
