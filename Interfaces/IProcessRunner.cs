
namespace MultiLanguageHelloWorld.Interfaces
{
    public interface IProcessRunner
    {
        string Run(
            string executable,
            string scriptPath,
            string message);
    }
}
