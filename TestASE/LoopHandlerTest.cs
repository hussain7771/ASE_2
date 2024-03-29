using ASE_2;

namespace TestASE
{
    [TestClass]
    public class LoopHandlerTests
    {
        [TestMethod]
        public void LessThanCondition_Test()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            variableProcessor.AssignVariableValue("x", 5);
            LoopHandler loopHandler = new LoopHandler(variableProcessor);
            string condition = "x < 10";

            // Act
            bool result = loopHandler.HandleCondition(condition);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GreaterThanCondition_Test()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            variableProcessor.AssignVariableValue("x", 15);
            LoopHandler loopHandler = new LoopHandler(variableProcessor);
            string condition = "x > 10";

            // Act
            bool result = loopHandler.HandleCondition(condition);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EqualToCondition_Test()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            variableProcessor.AssignVariableValue("x", 10);
            LoopHandler loopHandler = new LoopHandler(variableProcessor);
            string condition = "x = 10";

            // Act
            bool result = loopHandler.HandleCondition(condition);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InvalidCondition_Exception_Test()
        {
            // Arrange
            VariableProcessor variableProcessor = VariableProcessor.Singleton;
            LoopHandler loopHandler = new LoopHandler(variableProcessor);
            string condition = "x";

            try
            {
                // Act
                bool result = loopHandler.HandleCondition(condition);

                // Assert
                Assert.Fail("Expected ArgumentException was not thrown.");
            }
            catch (ArgumentException ex)
            {
                // Assert
                Assert.AreEqual("Invalid Conditin", ex.Message);
            }
        }

    }
}
