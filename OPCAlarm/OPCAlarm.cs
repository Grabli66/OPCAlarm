using SmsManager;
using System;
using System.Collections.Generic;

namespace OPCAlarm
{
    /// <summary>
    /// Входная точка для запуска приложения
    /// Запускает всё остальное
    /// </summary>
    public class ProgrammExecuter
    {
        /// <summary>
        /// Запускает
        /// </summary>
        public void Start()
        {
            var settings = new Dictionary<string, string>()
            {
                {  "service", "epochta" },
                {  "login", "grabli66@gmail.com" },
                {  "password", "NONE66" },
            };

            var smsManager = SmsManagerFactory.Create(settings);
            smsManager.SendSms("OPCAlarm", "+79190047646", "Как дела?");
        }
    }
}
