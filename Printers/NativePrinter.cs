
using System.Runtime.InteropServices;
using MultiLanguageHelloWorld.Interfaces;

namespace MultiLanguageHelloWorld.Printers
{
    public class NativeCPrinter : INativePrinter
    {
        [DllImport(
            "C/printer.dll",
            EntryPoint = "print_message",
            CallingConvention = CallingConvention.Cdecl,
            CharSet = CharSet.Ansi)]
        private static extern void PrintNative(string message);

        public void Print(string message)
        {
            PrintNative(message);
        }
    }
}
