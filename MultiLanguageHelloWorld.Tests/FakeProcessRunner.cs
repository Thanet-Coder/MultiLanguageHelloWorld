
using MultiLanguageHelloWorld.Interfaces;

namespace MultiLanguageHelloWorld.Tests
{
    public class FakeProcessRunner : IProcessRunner
    {
        public string? ReceivedExecutable { get; private set; }
        public string? ReceivedScriptPath { get; private set; }
        public string? ReceivedMessage { get; private set; }

        public string OutputToReturn { get; set; } = "Python Output: Hello World";

        public string Run(
            string executable,
            string scriptPath,
            string message)
        {
            ReceivedExecutable = executable;
            ReceivedScriptPath = scriptPath;
            ReceivedMessage = message;

            return OutputToReturn;
        }
    }
}
