
using MultiLanguageHelloWorld.Printers;

namespace MultiLanguageHelloWorld.Tests
{
    [Collection("ConsoleOutput")]
    public class PythonPrinterTests
    {


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
        public void Print_PassesMessageToProcessRunner()
        {
            // Arrange
            var fakeRunner = new FakeProcessRunner();
            var printer = new PythonPrinter(fakeRunner);

            string message = "Hello from C#!";

            // Act
            CaptureConsoleOutput(() => printer.Print(message));

            // Assert
            Assert.Equal(message, fakeRunner.ReceivedMessage);
        }// end of test method Print_PassesMessageToProcessRunner




        [Fact]
        public void Print_UsesPythonExecutable()
        {
            // Arrange
            var fakeRunner = new FakeProcessRunner();
            var printer = new PythonPrinter(fakeRunner);

            // Act
            CaptureConsoleOutput(() => printer.Print("Hello World"));

            // Assert
            Assert.Equal("python", fakeRunner.ReceivedExecutable);
        }// end of test method Print_UsesPythonExecutable




        [Fact]
        public void Print_UsesCorrectPythonScriptPath()
        {
            // Arrange
            var fakeRunner = new FakeProcessRunner();
            var printer = new PythonPrinter(fakeRunner);

            string expectedPath = Path.Combine(
                AppContext.BaseDirectory,
                "Python",
                "printer.py"
            );

            // Act
            CaptureConsoleOutput(() => printer.Print("Hello World"));

            // Assert
            Assert.Equal(expectedPath, fakeRunner.ReceivedScriptPath);
        }// end of test method Print_UsesCorrectPythonScriptPath




        [Fact]
        public void Print_WritesProcessRunnerOutputToConsole()
        {
            // Arrange
            var fakeRunner = new FakeProcessRunner
            {
                OutputToReturn = "Python Output: Testing 123"
            };

            var printer = new PythonPrinter(fakeRunner);

            // Act
            string output = CaptureConsoleOutput(
                () => printer.Print("Testing 123")
            );

            // Assert
            Assert.Equal("Python Output: Testing 123", output);
        }// end of test method Print_WritesProcessRunnerOutputToConsole





    }// end of class PythonPrinterTests

}// end of namespace MultiLanguageHelloWorld.Tests
