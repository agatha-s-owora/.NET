using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers; // Multithread safe
using System.Threading.Tasks;
using Topshelf.Builders;
using System.IO;

namespace One
{
    public class HeartBeat
    {
        private readonly Timer _timer;


        public HeartBeat()
        {
            _timer = new Timer(1000) { AutoReset = true }; // To keep the timer running
            _timer.Elapsed += timer_Elapsed;
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            string[] lines = { DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\Users\aowora\Desktop\Services\heartbeat.txt", lines);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
