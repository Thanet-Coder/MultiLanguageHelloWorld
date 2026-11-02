# MultiLanguageHelloWorld

**A C#/.NET 8 console application demonstrating multi-language interoperability, dependency injection, interface-based design and automated testing.**

## Overview

MultiLanguageHelloWorld is a console-based application developed using C# and .NET 8 in Visual Studio 2022.

The application allows users to enter messages and display them using different printer implementations, including C#, Python, JavaScript and native C.

Although the application's functionality is intentionally straightforward, its primary purpose is to demonstrate software engineering principles through a modular, maintainable and testable architecture.

The project explores two approaches to language interoperability:

- **External process execution:** Running Python and JavaScript scripts from C#.
- **Native interoperability:** Calling a compiled C library from C# using Platform Invocation Services (P/Invoke).

The project also incorporates dependency injection, interface-based abstractions, fake implementations and automated unit and integration testing.

## Key Features

- Interactive console menu for selecting printer implementations.
- Multiple implementations of a common `IMessagePrinter` interface.
- Dependency injection using `Microsoft.Extensions.DependencyInjection`.
- Separate services for menu handling and message management.
- Python and JavaScript integration through external processes.
- Native C integration using P/Invoke and a compiled DLL.
- Abstraction of external process execution through `IProcessRunner`.
- Abstraction of native C functionality through `INativePrinter`.
- Unit testing using fake dependencies.
- Integration testing for external scripts and the native C library.
- Automated testing using xUnit.

## Technologies

| Technology | Purpose |
|---|---|
| C# / .NET 8 | Main application and business logic |
| Visual Studio 2022 | Development environment |
| Python | External script integration |
| JavaScript / Node.js | External script integration |
| C | Native printer implementation |
| P/Invoke | Calling unmanaged C code from C# |
| Microsoft.Extensions.DependencyInjection | Dependency injection |
| xUnit | Unit and integration testing |
| Git / GitHub | Version control and source-code hosting |

## Software Architecture

The application follows an interface-based design, separating user interaction, application services and printer implementations.

### Printer Abstraction

The `IMessagePrinter` interface defines a common contract:

```csharp
public interface IMessagePrinter
{
    string Name { get; }
    void Print(string message);
}
```

Individual printer classes implement this interface, allowing the application to support different printing mechanisms without requiring the menu service to understand their internal implementations.

The available printers include:

- `CSharpPrinter`
- `FancyPrinter`
- `PythonPrinter`
- `JavaScriptPrinter`
- `CPrinter`

### Dependency Injection

The application uses the .NET dependency injection container to register and resolve services and printer implementations.

Multiple printers are injected through `IEnumerable<IMessagePrinter>`, enabling the menu to discover the available printing options.

This approach reduces coupling and makes it easier to introduce additional implementations.

### External Process Execution

The Python and JavaScript printers use an `IProcessRunner` abstraction to execute their respective scripts.

This separates process-management responsibilities from the printer classes and allows external execution to be replaced with a fake implementation during unit testing.

### Native C Interoperability

The native C implementation is compiled into `printer.dll`.

The application uses P/Invoke to call the exported C function from managed C# code.

Native functionality is separated into:

- `CPrinter` — implements `IMessagePrinter` and delegates printing.
- `INativePrinter` — defines the native printing contract.
- `NativeCPrinter` — performs the actual P/Invoke call.

This separation allows `CPrinter` to be unit-tested without loading the native DLL.

## Testing

The project includes a separate xUnit test project, `MultiLanguageHelloWorld.Tests`.

At the completion of the initial implementation, **24 automated tests were passing**.

Testing covers the managed printer implementations, message forwarding, external process integration and native C interoperability.

### Unit Testing

Unit tests verify individual components in isolation.

Fake implementations such as `FakeProcessRunner` and `FakeNativePrinter` replace external dependencies, allowing tests to verify behaviour without launching external processes or loading native libraries.

### Integration Testing

Integration tests exercise the real external components, including Python scripts, JavaScript scripts and the compiled C library.

The native C integration tests confirm that the library can be loaded and invoked with ordinary and empty messages without throwing managed exceptions.

These are integration smoke tests rather than exhaustive verification of native console output.

### Running the Tests

From the solution directory:

```powershell
dotnet test
```

The test suite requires the relevant external runtimes and native library to be available for integration testing.

## Getting Started

### Prerequisites

The current implementation is intended for **Windows x64**.

You will need:

- .NET 8 SDK
- Visual Studio 2022 (recommended) or another compatible .NET development environment
- Python installed and accessible through the configured executable name
- Node.js installed and accessible through the configured executable name
- The included Windows x64 `printer.dll`

The C source file is also included for reference and rebuilding the native library.

### Installation

Clone the repository:

```bash
git clone https://github.com/Thanet-Coder/MultiLanguageHelloWorld.git
```

Navigate to the project directory:

```bash
cd MultiLanguageHelloWorld
```

Restore dependencies:

```bash
dotnet restore
```

Build the solution:

```bash
dotnet build
```

### Running the Application

Run the main console application:

```bash
dotnet run --project MultiLanguageHelloWorld.csproj
```

Alternatively, open the solution in Visual Studio 2022 and start the main application.

The console menu allows users to select a printer implementation and enter a message.

## Cross-Platform Considerations

The managed .NET application uses technologies that can support multiple operating systems. However, the current native C implementation uses a Windows DLL compiled for x64.

Supporting Linux or macOS would require compiling platform-specific native libraries and configuring native-library loading accordingly.

External process execution may also require adjustments to executable names, paths and runtime configuration.

Cross-platform support is therefore a potential future enhancement rather than a feature of the current release.

## Future Improvements

Possible extensions include:

- Cross-platform native library support for Linux and macOS.
- More extensive integration tests that verify native output.
- Additional printer implementations.
- Improved exception handling and diagnostics for missing external runtimes.
- Automated build and test workflows using GitHub Actions.

## Learning Outcomes

This project provided practical experience with:

- Designing applications around interfaces and abstractions.
- Applying dependency injection to reduce coupling.
- Separating application responsibilities into services.
- Integrating managed and unmanaged code.
- Executing external language runtimes from C#.
- Writing unit tests using fake dependencies.
- Understanding the distinction between unit and integration testing.
- Maintaining a structured GitHub repository.

## Project Purpose

MultiLanguageHelloWorld was developed as a personal software engineering exercise and portfolio project.

Its emphasis is on **code organisation, extensibility, interoperability and testability**, rather than application complexity.

The repository demonstrates practical C# development skills alongside experience integrating multiple programming languages and testing components across managed and native boundaries.

## Author

**David Williams**

GitHub: [Thanet-Coder](https://github.com/Thanet-Coder)