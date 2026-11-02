using MultiLanguageHelloWorld.Printers;

namespace MultiLanguageHelloWorld.Tests
{
    public class CPrinterTests
    {
        [Fact]
        public void Print_PassesMessageToNativePrinter()
        {   // Arrange
            var fakeNativePrinter = new FakeNativePrinter();
            var cPrinter = new CPrinter(fakeNativePrinter);
            string testMessage = "Hello from C!";
            // Act
            cPrinter.Print(testMessage);
            // Assert
            Assert.Equal(testMessage, fakeNativePrinter.ReceivedMessage);
        }

        [Fact]
        public void Print_PassesEmptyMessageToNativePrinter()
        {   // Arrange
            var fakeNativePrinter = new FakeNativePrinter();
            var cPrinter = new CPrinter(fakeNativePrinter);
            string testMessage = "";
            // Act
            cPrinter.Print(testMessage);
            // Assert
            Assert.Equal(testMessage, fakeNativePrinter.ReceivedMessage);
        }

        [Fact]
        public void Name_ReturnsCPrinter()
        {
            // Arrange
            var fakeNativePrinter = new FakeNativePrinter();
            var printer = new CPrinter(fakeNativePrinter);

            // Act
            string name = printer.Name;

            // Assert
            Assert.Equal("C Printer", name);
        }

        [Fact]
        public void Print_PassesSpecialCharactersToNativePrinter()
        {
            // Arrange
            var fakeNativePrinter = new FakeNativePrinter();
            var printer = new CPrinter(fakeNativePrinter);

            string expectedMessage = "Hello, C! @#$% 123";

            // Act
            printer.Print(expectedMessage);

            // Assert
            Assert.Equal(expectedMessage, fakeNativePrinter.ReceivedMessage);
        }





    }// end of class
}// end of namespace
