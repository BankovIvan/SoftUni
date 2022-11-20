namespace Logger.ConsoleApp
{
    using Logger.ConsoleApp.Core;
    using Logger.ConsoleApp.CustomLayouts;
    using Logger.Core.Appenders;
    using Logger.Core.Enums;
    using Logger.Core.Formatting.Layouts;
    using Logger.Core.IO;
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();

            return;

            var simpleLayout = new SimpleLayout();
            var consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportLevel = ReportLevel.Error;

            var logger = new Logger.Core.Logging.Logger(consoleAppender);

            logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

            //return;

            var file = new LogFile("", "../../../Logs", "SOLID.log.txt");
            var fileAppender = new FileAppender(simpleLayout, file, ReportLevel.Info);
            //consoleAppender.ReportLevel = ReportLevel.Error;
            logger = new Logger.Core.Logging.Logger(fileAppender);

            logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");

            var customLayout = new XMLLayout();
            consoleAppender = new ConsoleAppender(customLayout);
            //consoleAppender.ReportLevel = ReportLevel.Error;
            logger = new Logger.Core.Logging.Logger(consoleAppender);

            logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");


        }
    }
}
