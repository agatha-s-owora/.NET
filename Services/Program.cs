using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace One
{
    public class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<HeartBeat>(s =>
                {
                    s.ConstructUsing(heartBeat => new HeartBeat());
                    s.WhenStarted(heartBeat => heartBeat.Start());
                    s.WhenStopped(heartBeat => heartBeat.Stop());
                });

                x.RunAsLocalSystem();
               
                x.SetServiceName("HeartbeatService");
                x.SetDisplayName("Heartbeat Service");
                x.SetDescription("Sample Heartbeat Service");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
