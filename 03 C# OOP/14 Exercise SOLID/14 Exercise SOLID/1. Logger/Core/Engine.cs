namespace Logger.ConsoleApp.Core
{
    using Logger.ConsoleApp.Factories;
    using Logger.ConsoleApp.Factories.Interfaces;
    using Logger.Core.Appenders.Interfaces;
    using Logger.Core.Enums;
    using Logger.Core.Formatting.Layouts.Interfaces;
    using Logger.Core.IO.Interfaces;
    using Logger.Core.IO;
    using Logger.Core.Logging.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Engine : IEngine
    {
        private readonly ICollection<IAppender> appenders;
        private ILogger logger;

        private readonly ILayoutFactory layoutFactory;
        private readonly IAppenderFactory appenderFactory;

        public Engine()
        {
            this.layoutFactory = new LayoutFactory();
            this.appenderFactory = new AppenderFactory();
            this.appenders = new HashSet<IAppender>();
            //this.
        }

        public void Run()
        {
            try
            {
                Init();
                this.logger = new Logger.Core.Logging.Logger(appenders);

                string[] arrInput;

                while((arrInput = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries))[0] != "End") 
                { 
                    string reportLevel = arrInput[0];
                    string dateTime = arrInput[1];
                    string message = arrInput[2];

                    switch (reportLevel)
                    {
                        case "INFO":
                            logger.Info(dateTime, message);
                            break;

                        case "WARNING":
                            logger.Warning(dateTime, message);
                            break;

                        case "ERROR":
                            logger.Error(dateTime, message);
                            break;

                        case "CRITICAL":
                            logger.Critical(dateTime, message);
                            break;

                        case "FATAL":
                            logger.Fatal(dateTime, message);
                            break;

                        default:
                            logger.Info(dateTime, message);
                            break;
                    }

                }

            }
            catch(Exception ex)
            {
                
            }

        }

        public void Init()
        {
            int nRepeat = int.Parse(Console.ReadLine());

            for (int i = 0; i < nRepeat; i++)
            {
                string[] arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string appenderType = arrInput[0];
                string layoutType = arrInput[1];

                ILayout layout = this.layoutFactory.CreateLayout(layoutType);
                ReportLevel reportLevel = ReportLevel.Info;

                if (arrInput.Length > 2)
                {
                    if (!Enum.TryParse(arrInput[2], out reportLevel))
                    {
                        reportLevel = ReportLevel.Info;
                    }
                }

                IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout, reportLevel, null);
                appenders.Add(appender);
            }
        }
    }
}
