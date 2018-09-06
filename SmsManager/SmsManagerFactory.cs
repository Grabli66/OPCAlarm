using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmsManager
{
    /// <summary>
    /// Фабрика СМС мэнеджеров
    /// </summary>
    public class SmsManagerFactory
    {
        /// <summary>
        /// Название поля с именем сервиса
        /// </summary>
        public const string FIELD_NAME = "NAME";

        /// <summary>
        /// Название сервиса в настройках
        /// </summary>
        public const string SERVICE_NAME = "service";

        /// <summary>
        /// Создаёт SmsManager по заданным настройкам
        /// </summary>
        /// <returns></returns>
        public static SmsManager Create(Dictionary<string, string> settings)
        {
            settings.TryGetValue(SERVICE_NAME, out var seviceName);
            if (string.IsNullOrEmpty(seviceName))
                throw new SmsManagerException("Не задан тип сервиса СМС");

            var managerTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => (x.BaseType == typeof(SmsManager)) && (!x.IsAbstract));

            foreach (var managerType in managerTypes)
            {
                var name = managerType.GetField(FIELD_NAME).GetValue(null);
                if (!seviceName.Equals(name))
                    continue;

                var manager = Activator.CreateInstance(managerType, new[] { settings }) as SmsManager;
                return manager;
            }

            throw new SmsManagerException("Не поддерживаемый тип сервиса отправки СМС");
        }
    }
}
