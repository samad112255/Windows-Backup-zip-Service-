using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace backup_Service
{
    public partial class Service1 : ServiceBase
    {
        public static int time = Int32.Parse(ConfigurationManager.AppSettings["time"]);
        private Timer timer = null;
        public Service1()
        {
            InitializeComponent();
            
        }

        private void OnCreateBackup(object sender, ElapsedEventArgs e)
        {
            ZipBackup.BackupAndDelete();
        }
        

        protected override void OnStart(string[] args)
        {
          
            timer = new Timer();
            timer.Interval = 1000 * time; // 60 seconds
            timer.Elapsed += new ElapsedEventHandler(this.OnCreateBackup);
            timer.Enabled = true;

        }

        protected override void OnStop()
        {
            Console.WriteLine("service has started");
            timer.Stop();
            timer = null;
        }
    }
}
