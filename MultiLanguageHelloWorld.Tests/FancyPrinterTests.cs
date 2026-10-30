
using MultiLanguageHelloWorld.Printers;

namespace MultiLanguageHelloWorld.Tests
{
    [Collection("ConsoleOutput")]

    public class FancyPrinterTests
    {
        [Theory]
        [InlineData("Hello", "*********")]
        [InlineData("Hi", "******")]
        [InlineData("", "****")]
        public void Print_Message_CreatesCorrectBorder(
            string message,
            string expectedBorder)
        {
            // Arrange
            var printer = new FancyPrinter();
            using var writer = new StringWriter();

            TextWriter originalOutput = Console.Out;

            try
            {
                Console.SetOut(writer);

                // Act
                printer.Print(message);


                // Assert
                string output = writer.ToString();

                string[] lines = output.Split(
                    Environment.NewLine,
                    StringSplitOptions.None
                );

                Assert.Equal(4, lines.Length);

                Assert.Equal(expectedBorder, lines[0]);
                Assert.Equal($"* {message} *", lines[1]);
                Assert.Equal(expectedBorder, lines[2]);
                Assert.Equal("", lines[3]);

            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }// end of Print_Message_CreatesCorrectBorder Test
    }// end of class FancyPrinterTests
}// end of namespace MultiLanguageHelloWorld.Tests
