
using MultiLanguageHelloWorld.Interfaces;

namespace MultiLanguageHelloWorld.Printers
{
    public class FancyPrinter : IMessagePrinter
    {
        public string Name => "Fancy Printer";

        public void Print(string message)
        {
            string border = new string('*', message.Length + 4);

            Console.WriteLine(border);
            Console.WriteLine($"* {message} *");
            Console.WriteLine(border);
        }
    }
}
