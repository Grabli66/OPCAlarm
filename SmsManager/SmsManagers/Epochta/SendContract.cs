using System;
using System.Xml.Serialization;

namespace SmsManager.SmsManagers.Epochta
{
    /// <summary>
    /// Контракт для отправки СМС
    /// </summary>
    internal class SendContract
    {
        /// <summary>
        /// Имя отправителя
        /// </summary>
        public readonly string Sender;

        /// <summary>
        /// Номер телефона получателя
        /// </summary>
        public readonly string RecepientPhone;

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public readonly string Text;

        /// <summary>
        /// Логин для доступа к сервиса
        /// </summary>
        public readonly string Login;

        /// <summary>
        /// Пароль доступа к сервису
        /// </summary>
        public readonly string Password;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="text"></param>
        public SendContract(string sender, string recepientPhone, string text, string login, string password)
        {
            Sender = sender;
            RecepientPhone = recepientPhone;
            Text = text;
            Login = login;
            Password = password;
        }

        /// <summary>
        /// Преобразует в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $@"<SMS>
                    <operations>
                        <operation>SEND</operation>
                    </operations>
                    <authentification>
                        <username>{Login}</username>
                        <password>{Password}</password>
                    </authentification>
                    <message>
                        <sender>{Sender}</sender>       
                        <text>{Text}</text>       
                    </message>
                    <numbers>
                        <number>{RecepientPhone}</number>
                    </numbers>
                </SMS>";
        }
    }
}
