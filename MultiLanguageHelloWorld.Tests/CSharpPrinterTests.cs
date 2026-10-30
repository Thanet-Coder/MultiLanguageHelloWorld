
using MultiLanguageHelloWorld.Printers;

namespace MultiLanguageHelloWorld.Tests
{
    [Collection("ConsoleOutput")]

    public class CSharpPrinterTests
    {
        [Theory]
        [InlineData("Hello World", "C# Output: Hello World")]
        [InlineData("", "C# Output: ")]
        [InlineData("Hello from C#!", "C# Output: Hello from C#!")]

        public void Print_Message_WritesExpectedOutput(
            string message,
            string expectedOutput)
        {
            // Arrange
            var printer = new CSharpPrinter();
            using var writer = new StringWriter();

            TextWriter originalOutput = Console.Out;

            try
            {
                Console.SetOut(writer);

                // Act
                printer.Print(message);

                // Assert
                Assert.Equal(
                    expectedOutput + Environment.NewLine,
                    writer.ToString()
                );
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }// end of Print_Message_WritesExpectedOutput Test
    }// end of class CSharpPrinterTests
}// end of namespace MultiLanguageHelloWorld.Tests
