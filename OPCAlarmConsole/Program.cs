using OPCAlarm;

namespace OPCAlarmConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var opcAlarm = new ProgrammExecuter();
            opcAlarm.Start();
        }
    }
}
