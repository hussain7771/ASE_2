using ASE_2;

namespace TestASE
{
    [TestClass]
    public class VariableProcessorTests
    {
        [TestMethod]
        public void IsVariableExisting_VariableExists_ReturnsTrue()
        {
            // Arrange
            VariableProcessor processor = VariableProcessor.Singleton;
            processor.AssignVariableValue("x", 10);

            // Act
            bool result = processor.IsVariableExisting("x");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsVariableExisting_VariableDoesNotExist_ReturnsFalse()
        {
            // Arrange
            VariableProcessor processor = VariableProcessor.Singleton;

            // Act
            bool result = processor.IsVariableExisting("y");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetVariableValue_VariableExists_ReturnsValue()
        {
            // Arrange
            VariableProcessor processor = VariableProcessor.Singleton;
            processor.AssignVariableValue("x", 10);

            // Act
            int result = processor.GetVariableValue("x");

            // Assert
            Assert.AreEqual(10, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetVariableValue_VariableDoesNotExist_ThrowsArgumentException()
        {
            // Arrange
            VariableProcessor processor = VariableProcessor.Singleton;

            // Act
            int result = processor.GetVariableValue("y");

            // Assert
            // Expects ArgumentException to be thrown
        }

        [TestMethod]
        public void AssignVariableValue_NewVariable_AssignsCorrectly()
        {
            // Arrange
            VariableProcessor processor = VariableProcessor.Singleton;

            // Act
            processor.AssignVariableValue("x", 10);

            // Assert
            Assert.IsTrue(processor.IsVariableExisting("x"));
            Assert.AreEqual(10, processor.GetVariableValue("x"));
        }

        [TestMethod]
        public void AssignVariableValue_ExistingVariable_UpdatesValue()
        {
            // Arrange
            VariableProcessor processor = VariableProcessor.Singleton;
            processor.AssignVariableValue("x", 10);

            // Act
            processor.AssignVariableValue("x", 20);

            // Assert
            Assert.AreEqual(20, processor.GetVariableValue("x"));
        }

        [TestMethod]
        public void ClearDataStorage_ClearsAllVariables()
        {
            // Arrange
            VariableProcessor processor = VariableProcessor.Singleton;
            processor.AssignVariableValue("x", 10);
            processor.AssignVariableValue("y", 20);

            // Act
            processor.ClearDataStorage();

            // Assert
            Assert.IsFalse(processor.IsVariableExisting("x"));
            Assert.IsFalse(processor.IsVariableExisting("y"));
        }

    }
}
