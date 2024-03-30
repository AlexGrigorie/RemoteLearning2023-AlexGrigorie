using Serilog;
using VendingMachine_Business.Interfaces;
using Microsoft.Extensions.Configuration;

namespace VendingMachine_Business.Services
{
    internal class LoggerService : ILoggerService
    {
        private readonly ILogger logger;

        public LoggerService()
        {
            var configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json")
                 .Build();

            logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }
        public void LogError(Exception ex)
        {
            logger.Error($"An error occurred:{ex.Message}\nStack trace:{ex.StackTrace}\nInner Exceptions:{ex.Message}");
        }

        public void LogInformation(string message)
        {
            logger.Information(message);
        }
    }
}
