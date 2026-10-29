
using MultiLanguageHelloWorld.Interfaces;

namespace MultiLanguageHelloWorld.Services
{
    public class MenuService
    {
        private readonly IReadOnlyList<IMessagePrinter> _printers;

        public MenuService(IEnumerable<IMessagePrinter> printers)
        {
            _printers = printers.ToList();
        }

        public void Run()
        {
            Console.WriteLine("MultiLanguageHelloWorld");
            Console.WriteLine("-----------------------");

            Console.Write("Enter your message: ");
            string message = Console.ReadLine() ?? "";

            Console.WriteLine();
            Console.WriteLine("Choose your printer:");

            // Generate menu options dynamically
            for (int i = 0; i < _printers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_printers[i].Name}");
            }

            Console.Write("Enter option: ");
            string option = Console.ReadLine() ?? "";

            // Validate the user's selection
            if (int.TryParse(option, out int selection) &&
                selection >= 1 &&
                selection <= _printers.Count)
            {
                IMessagePrinter printer = _printers[selection - 1];

                printer.Print(message);
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }
        }
    }
}
