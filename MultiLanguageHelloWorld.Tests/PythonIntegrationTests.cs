
using MultiLanguageHelloWorld.Printers;
using MultiLanguageHelloWorld.Services;

namespace MultiLanguageHelloWorld.Tests
{
    [Collection("ConsoleOutput")]

    public class PythonIntegrationTests
    {
        [Fact]
        public void Run_ExecutesPythonScriptAndReturnsOutput()
        {
            // Arrange
            var runner = new ProcessRunner();

            string scriptPath = Path.Combine(
                AppContext.BaseDirectory,
                "Python",
                "printer.py"
            );

            string message = "Hello from integration testing!";

            // Act
            string output = runner.Run(
                "python",
                scriptPath,
                message
            );

            // Assert
            Assert.Equal(
                "Python Output: Hello from integration testing!",
                output.TrimEnd('\r', '\n')
            );
        }// end of method Run_ExecutesPythonScriptAndReturnsOutput


        [Fact]
        public void PythonPrinter_ExecutesPythonAndWritesOutput()
        {
            // Arrange
            var runner = new ProcessRunner();
            var printer = new PythonPrinter(runner);

            string message = "Hello from the complete pipeline!";

            using var writer = new StringWriter();
            TextWriter originalOutput = Console.Out;

            try
            {
                Console.SetOut(writer);

                // Act
                printer.Print(message);

                // Assert
                Assert.Equal(
                    "Python Output: Hello from the complete pipeline!",
                    writer.ToString().TrimEnd('\r', '\n')
                );
            }
            finally
            {
                Console.SetOut(originalOutput);
            }
        }// end of method PythonPrinter_ExecutesPythonAndWritesOutput


    }// end of class PythonIntegrationTests
}// end of namespace MultiLanguageHelloWorld.Tests
