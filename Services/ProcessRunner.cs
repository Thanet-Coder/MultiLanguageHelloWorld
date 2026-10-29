
using System.Diagnostics;
using MultiLanguageHelloWorld.Interfaces;

namespace MultiLanguageHelloWorld.Services
{
    public class ProcessRunner : IProcessRunner
    {
        public string Run(
            string executable,
            string scriptPath,
            string message)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = executable,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            startInfo.ArgumentList.Add(scriptPath);
            startInfo.ArgumentList.Add(message);

            using var process = Process.Start(startInfo)
                ?? throw new InvalidOperationException(
                    $"Unable to start {executable}.");

            // Capture output and errors concurrently
            Task<string> outputTask =
                process.StandardOutput.ReadToEndAsync();

            Task<string> errorTask =
                process.StandardError.ReadToEndAsync();

            process.WaitForExit();

            string output = outputTask.GetAwaiter().GetResult();
            string errors = errorTask.GetAwaiter().GetResult();

            if (process.ExitCode != 0)
            {
                throw new InvalidOperationException(
                    $"{executable} failed: {errors}");
            }

            return output;
        }
    }
}
