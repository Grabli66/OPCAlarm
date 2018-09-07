using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace SmsManager.SmsManagers.Epochta
{
    /// <summary>
    /// Отправщик через сервис https://www.epochta.ru/
    /// </summary>
    public class EpochtaManager : SmsManager
    {
        /// <summary>
        /// Название сервиса epochta
        /// </summary>
        public const string NAME = "epochta";

        /// <summary>
        /// Название параметра Login
        /// </summary>
        public const string LOGIN_NAME = "login";

        /// <summary>
        /// Название параметра Password
        /// </summary>
        public const string PASSWORD_NAME = "password";

        /// <summary>
        /// Логин доступа к сервису
        /// </summary>
        public readonly string Login;

        /// <summary>
        /// Пароль доступа к сервису
        /// </summary>
        public readonly string Password;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="settings"></param>
        public EpochtaManager(Dictionary<string, string> settings) : base(settings)
        {
            try
            {
                Login = settings[LOGIN_NAME];
                Password = settings[PASSWORD_NAME];
            } catch
            {
                throw new SmsManagerException("Неправильно заданы параметры доступа к сервису");
            }
        }

        /// <summary>
        /// Отправляет СМС
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="recepientPhone"></param>
        /// <param name="text"></param>
        public override void SendSms(string sender, string recepientPhone, string text)
        {
            var request = WebRequest.Create("http://api.myatompark.com/members/sms/xml.php") as HttpWebRequest;
            request.Method = "Post";
            request.ContentType = "application/x-www-form-urlencoded";
            var smsContract = new SendContract(sender, recepientPhone, text, Login, Password);

            var data = Encoding.UTF8.GetBytes(smsContract.ToString());
            request.ContentLength = data.Length;
            var dataStream = request.GetRequestStream();
            dataStream.Write(data, 0, data.Length);
            using (var response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new SmsManagerException(
                    $"Ошибка работы сервиса (HTTP {response.StatusCode}: {response.StatusDescription}).");

                // TODO: проверка статуса
                using (var responseStream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(responseStream))
                    {
                        var responseFromServer = reader.ReadToEnd();
                    }
                }
            }
        }
    }
}
