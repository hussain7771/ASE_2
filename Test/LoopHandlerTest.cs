using ASE_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class LoopHandlerTests
    {
        [TestMethod]
        public void HandleCondition_ShouldEvaluateConditionCorrectly()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            LoopHandler loopHandler = new LoopHandler(variableProcessor);
            variableProcessor.AssignVariableValue("x", 5);

            // Act
            bool result1 = loopHandler.HandleCondition("x < 10");
            bool result2 = loopHandler.HandleCondition("x > 3");
            bool result3 = loopHandler.HandleCondition("x = 5");
            bool result4 = loopHandler.HandleCondition("x <= 5");
            bool result5 = loopHandler.HandleCondition("x >= 5");

            // Assert
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsTrue(result3);
            Assert.IsTrue(result4);
            Assert.IsTrue(result5);
        }

        [TestMethod]
        public void Evaluate_ShouldThrowExceptionForInvalidCondition()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            LoopHandler loopHandler = new LoopHandler(variableProcessor);
            variableProcessor.AssignVariableValue("x", 5);

            // Act and assert
            Assert.ThrowsException<ArgumentException>(() => loopHandler.Evaluate("x invalidcondition"));
        }

        [TestMethod]
        public void Evaluate_ShouldThrowExceptionForNonNumericComparisonValue()
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
