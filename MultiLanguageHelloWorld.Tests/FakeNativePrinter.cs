
using MultiLanguageHelloWorld.Interfaces;

namespace MultiLanguageHelloWorld.Tests
{
    public class FakeNativePrinter : INativePrinter
    {
        public string? ReceivedMessage { get; private set; }

        public void Print(string message)
        {
            ReceivedMessage = message;
        }
    }
}
