
using MultiLanguageHelloWorld.Interfaces;

namespace MultiLanguageHelloWorld.Printers
{
    public class JavaScriptPrinter : IMessagePrinter
    {
        private readonly IProcessRunner _processRunner;

        public string Name => "JavaScript Printer";

        public JavaScriptPrinter(IProcessRunner processRunner)
        {
            _processRunner = processRunner;
        }// end of constructor

        public void Print(string message)
        {
            string scriptPath = Path.Combine(
                AppContext.BaseDirectory,
                "JavaScript",
                "printer.js"
            );

            string output = _processRunner.Run(
                "node",
                scriptPath,
                message
            );

            Console.Write(output);
        }// end of Print method

    }// end of class JavaScriptPrinter

}// end of namespace MultiLanguageHelloWorld.Printers
