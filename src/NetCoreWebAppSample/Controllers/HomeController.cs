namespace NetCoreWebAppSample.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class HomeController : Controller
    {
        private static readonly Common.Logging.ILog CommonLoggingLogger = Common.Logging.LogManager.GetLogger<HomeController>();

        private ILogger<HomeController> _microsoftLogger;

        public HomeController(ILogger<HomeController> microsoftLogger)
        {
            _microsoftLogger = microsoftLogger;
        }

        public IActionResult Index()
        {
            _microsoftLogger.LogInformation("Log from microsoft logger.");
            CommonLoggingLogger.Info("Log from Common Logging directly, which does NOT need dependency injection.");

            return Content(
                "The default logger adapter for common.logging is configured with the DebugLoggerFactoryAdapter in appsettings.json\r\n\r\n" +
                "Have you started this project with debugging? If yes...\r\n" +
                "Please check the Debug console output of your Visual Studio. There should be two logs, one from Microsoft Logger, one form Common.Logging directly.\r\n" +
                "By checking the running console, there is one log from Microsoft Logger, which is the expected behavior.");
        }
    }
}
