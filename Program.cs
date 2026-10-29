
using Microsoft.Extensions.DependencyInjection;
using MultiLanguageHelloWorld.Interfaces;
using MultiLanguageHelloWorld.Printers;
using MultiLanguageHelloWorld.Services;

namespace MultiLanguageHelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create service collection
            var services = new ServiceCollection();
            services.AddTransient<IProcessRunner, ProcessRunner>();

            // Register printer implementations
            services.AddTransient<IMessagePrinter, CSharpPrinter>();
            services.AddTransient<IMessagePrinter, FancyPrinter>();
            services.AddTransient<IMessagePrinter, PythonPrinter>();

            // Register menu service
            services.AddTransient<MenuService>();

            // Build dependency injection container
            using var serviceProvider = services.BuildServiceProvider();

            // Resolve menu service
            MenuService menu =
                serviceProvider.GetRequiredService<MenuService>();

            // Run application
            menu.Run();
        }
    }
}
