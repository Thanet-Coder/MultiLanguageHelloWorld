
using MultiLanguageHelloWorld.Interfaces;

namespace MultiLanguageHelloWorld.Printers
{
    public class CSharpPrinter : IMessagePrinter
    {
        public string Name => "C# Printer";

        public void Print(string message)
        {
            Console.WriteLine($"C# Output: {message}");
        }
    }
}
