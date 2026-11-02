
using MultiLanguageHelloWorld.Interfaces;

namespace MultiLanguageHelloWorld.Printers
{
    public class CPrinter : IMessagePrinter
    {
        private readonly INativePrinter _nativePrinter;

        public string Name => "C Printer";

        public CPrinter(INativePrinter nativePrinter)
        {
            _nativePrinter = nativePrinter;
        }

        public void Print(string message)
        {
            _nativePrinter.Print(message);
        }
    }
}
