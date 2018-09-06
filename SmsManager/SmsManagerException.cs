using System;

namespace SmsManager
{
    /// <summary>
    /// Исключение SmsManager которое кидает данная сборка в случае сбоя
    /// </summary>
    public class SmsManagerException : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message"></param>
        public SmsManagerException(string message) : base(message)
        {
        }
    }
}
