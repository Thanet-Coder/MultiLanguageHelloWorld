
using Xunit;

[assembly: CollectionBehavior(DisableTestParallelization = true)]

namespace MultiLanguageHelloWorld.Tests
{
    [CollectionDefinition("ConsoleOutput")]
    public class ConsoleOutputCollection
    {
    }
}
