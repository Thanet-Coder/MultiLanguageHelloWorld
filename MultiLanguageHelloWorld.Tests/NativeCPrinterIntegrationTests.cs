
using MultiLanguageHelloWorld.Printers;

namespace MultiLanguageHelloWorld.Tests
{
    public class NativeCPrinterIntegrationTests
    {
        [Fact]
        public void Print_WithValidMessage_DoesNotThrow()
        {
            // Arrange
            var printer = new NativeCPrinter();
            string message = "Hello from C integration test!";

            // Act
            var exception = Record.Exception(() => printer.Print(message));

            // Assert
            Assert.Null(exception);
        }// end of method Print_WithValidMessage_DoesNotThrow


        [Fact]
        public void Print_WithEmptyMessage_DoesNotThrow()
        {
            // Arrange
            var printer = new NativeCPrinter();
            string message = "";

            // Act
            var exception = Record.Exception(() => printer.Print(message));

            // Assert
            Assert.Null(exception);
        }// end of method Print_WithEmptyMessage_DoesNotThrow

    }// end of class NativeCPrinterIntegrationTests

}// end of namespace MultiLanguageHelloWorld.Tests
