using GOlazs;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void TestProcessInputFileOne()
        {
            // Arrange
            string fileIdentifier = "1";
            string expectedOutput = "1,2,4,8";

            // Act
            Program.ProcessInputFile(fileIdentifier);

            // Assert
            string actualOutput = File.ReadAllText($"output{fileIdentifier}.txt");
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestProcessInputFileTwo()
        {
            // Arrange
            string fileIdentifier = "2";
            string expectedOutput = "-3,3,-3,3";

            // Act
            Program.ProcessInputFile(fileIdentifier);

            // Assert
            string actualOutput = File.ReadAllText($"output{fileIdentifier}.txt");
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestProcessInputFileThree()
        {
            // Arrange
            string fileIdentifier = "3";
            string expectedOutput = "4,8,12,20";

            // Act
            Program.ProcessInputFile(fileIdentifier);

            // Assert
            string actualOutput = File.ReadAllText($"output{fileIdentifier}.txt");
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestProcessInputFileFour()
        {
            // Arrange
            string fileIdentifier = "4";
            string expectedOutput = "0,12,12,12";

            // Act
            Program.ProcessInputFile(fileIdentifier);

            // Assert
            string actualOutput = File.ReadAllText($"output{fileIdentifier}.txt");
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestProcessInputFileFive()
        {
            // Arrange
            string fileIdentifier = "5";
            string expectedOutput = "1,1,1,1";

            // Act
            Program.ProcessInputFile(fileIdentifier);

            // Assert
            string actualOutput = File.ReadAllText($"output{fileIdentifier}.txt");
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}