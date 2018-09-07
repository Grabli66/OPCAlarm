using OPCAlarm;
using System.ServiceProcess;

namespace OPCAlarmService
{
    /// <summary>
    /// Сервис OPCAlarm
    /// </summary>
    public partial class OPCAlarmService : ServiceBase
    {
        /// <summary>
        /// Исполнитель оснойной логики программы
        /// </summary>
        private readonly ProgrammExecuter ProgrammExecuter;

        /// <summary>
        /// 
        /// </summary>
        public OPCAlarmService()
        {
            InitializeComponent();
            ProgrammExecuter = new ProgrammExecuter();
        }

        /// <summary>
        /// Вызывается при запуске службы
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            ProgrammExecuter.Start();
        }

        /// <summary>
        /// Вызывается при остановки службы
        /// </summary>
        protected override void OnStop()
        {
            ProgrammExecuter.Stop();
        }
    }
}
