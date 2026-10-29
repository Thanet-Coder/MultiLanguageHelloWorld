
namespace MultiLanguageHelloWorld.Interfaces
{
    public interface IMessagePrinter
    {
        string Name { get; }

        void Print(string message);
    }
}


