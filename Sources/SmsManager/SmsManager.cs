using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SmsManager
{
    /// <summary>
    /// Отвечает за связь с СМС сервисами
    /// </summary>
    public abstract class SmsManager
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="settings"></param>
        protected SmsManager(Dictionary<string, string> settings)
        {
        }

        /// <summary>
        /// Отправляет SMS
        /// </summary>
        public abstract void SendSms(string sender, string recepientPhone, string text);
    }
}
