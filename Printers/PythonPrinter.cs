
using MultiLanguageHelloWorld.Interfaces;

namespace MultiLanguageHelloWorld.Printers
{
    public class PythonPrinter : IMessagePrinter
    {
        private readonly IProcessRunner _processRunner;

        public string Name => "Python Printer";

        public PythonPrinter(IProcessRunner processRunner)
        {
            _processRunner = processRunner;
        }

        public void Print(string message)
        {
            string scriptPath = Path.Combine(
                AppContext.BaseDirectory,
                "Python",
                "printer.py"
            );

            string output = _processRunner.Run(
                "python",
                scriptPath,
                message
            );

            Console.Write(output);
        }
    }
}
