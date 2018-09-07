using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using SmsManager;
using System;
using System.IO;
using System.Reflection;

namespace OPCAlarm
{
    /// <summary>
    /// Входная точка для запуска приложения
    /// Запускает всё остальное
    /// </summary>
    public class ProgrammExecuter
    {
        /// <summary>
        /// Папка для логов
        /// </summary>
        public const string LOG_PATH = "Logs";

        /// <summary>
        /// Название логгера
        /// </summary>
        public const string LOGGER_NAME = "OPCAlarm";

        /// <summary>
        /// Логгер
        /// </summary>
        public static readonly ILog Logger = LogManager.GetLogger(LOGGER_NAME);

        /// <summary>
        /// Конфигурирует лог
        /// </summary>
        private void ConfigureLogger()
        {
            var layout = new PatternLayout("%date [%thread] %-5level - %message%newline");
            var fileAppender = new RollingFileAppender()
            {
                Name = LOGGER_NAME,
                Layout = layout,
                File = $"{LOG_PATH}/{LOGGER_NAME}.log",
                AppendToFile = true
            };

            fileAppender.ActivateOptions();
            BasicConfigurator.Configure(fileAppender);
        }

        /// <summary>
        /// Загружает настройки из файла
        /// </summary>
        private void LoadSettings()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            var directory = Path.GetDirectoryName(path);
            Logger.Debug(directory);
            Logger.Info(directory);
            Logger.Fatal(directory);
        }

        /// <summary>
        /// Запускает
        /// </summary>
        public void Start()
        {
            ConfigureLogger();
            LoadSettings();

            //var settings = new Dictionary<string, string>()
            //{
            //    {  "service", "epochta" },
            //    {  "login", "grabli66@gmail.com" },
            //    {  "password", "NONE66" },
            //};

            //var smsManager = SmsManagerFactory.Create(settings);
            //smsManager.SendSms("OPCAlarm", "+79190047646", "Как дела?");
        }

        /// <summary>
        /// Останавливает выполнение
        /// </summary>
        public void Stop()
        {
        }
    }
}
