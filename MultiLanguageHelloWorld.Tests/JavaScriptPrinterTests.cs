
using MultiLanguageHelloWorld.Printers;

namespace MultiLanguageHelloWorld.Tests
{
    public class JavaScriptPrinterTests
    {
        [Fact]
        public void Print_UsesNodeExecutable()
        {
            // Arrange
            var fakeRunner = new FakeProcessRunner();
            var printer = new JavaScriptPrinter(fakeRunner);

            // Act
            printer.Print("Hello World");

            // Assert
            Assert.Equal("node", fakeRunner.ReceivedExecutable);
        }// end of Print_UsesNodeExecutable Test

        [Fact]
        public void Print_PassesMessageToProcessRunner()
        {
            // Arrange
            var fakeRunner = new FakeProcessRunner();
            var printer = new JavaScriptPrinter(fakeRunner);
            string expectedMessage = "Hello World";
            // Act
            printer.Print(expectedMessage);
            // Assert
            Assert.Equal(expectedMessage, fakeRunner.ReceivedMessage);

        }// end of Print_PassesMessageToProcessRunner Test

        [Fact]
        public void Print_UsesCorrectJavaScriptScriptPath()
        {
            // Arrange
            var fakeRunner = new FakeProcessRunner();
            var printer = new JavaScriptPrinter(fakeRunner);
            string expectedPath = Path.Combine(
                AppContext.BaseDirectory,
                "JavaScript",
                "printer.js"
            );

            // Act
            printer.Print("Hello World");

            // Assert
            Assert.Equal(expectedPath, fakeRunner.ReceivedScriptPath);

        }// end of Print_UsesCorrectJavaScriptScriptPath Test

        private static string CaptureConsoleOutput(Action action)
        {
            using var writer = new StringWriter();
            TextWriter originalOutput = Console.Out;

            try
            {
                Console.SetOut(writer);

                action();

                return writer.ToString();
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }// end of method CaptureConsoleOutput


        [Fact]
        public void Print_WritesProcessRunnerOutputToConsole()
        {
            // Arrange
            var fakeRunner = new FakeProcessRunner
            {
                OutputToReturn = "JavaScript Output: Testing 123"
            };

            var printer = new JavaScriptPrinter(fakeRunner);

            // Act
            string output = CaptureConsoleOutput(
                () => printer.Print("Testing 123")
            );

            // Assert
            Assert.Equal("JavaScript Output: Testing 123", output);

        }// end of Print_WritesProcessRunnerOutputToConsole Test


    }// end of JavaScriptPrinterTests class
}// end of MultiLanguageHelloWorld.Tests namespace
