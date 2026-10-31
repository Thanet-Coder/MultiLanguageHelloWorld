
using MultiLanguageHelloWorld.Printers;
using MultiLanguageHelloWorld.Services;

namespace MultiLanguageHelloWorld.Tests
{
    [Collection("ConsoleOutput")]

    public class JavaScriptIntegrationTests
    {
        [Fact]
        public void ProcessRunner_ExecutesJavaScriptScript()
        {
            // Arrange
            var runner = new ProcessRunner();

            string scriptPath = Path.Combine(
                AppContext.BaseDirectory,
                "JavaScript",
                "printer.js"
            );

            // Act
            string output = runner.Run(
                "node",
                scriptPath,
                "Hello from integration testing!"
            );

            // Assert
            Assert.Equal(
                "JavaScript Output: Hello from integration testing!",
                output.Trim()
            );
        }// end of test method ProcessRunner_ExecutesJavaScriptScript


        [Fact]
        public void JavaScriptPrinter_ExecutesScriptAndWritesOutput()
        {
            // Arrange
            var runner = new ProcessRunner();
            var printer = new JavaScriptPrinter(runner);

            // Act
            string output = CaptureConsoleOutput(
                () => printer.Print("Hello from JavaScript!")
            );

            // Assert
            Assert.Equal(
                "JavaScript Output: Hello from JavaScript!",
                output.Trim()
            );
        }


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
        }





    }// end of class JavaScriptIntegrationTests
}// end of namespace MultiLanguageHelloWorld.Tests
