using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Timers;
using System.Runtime.InteropServices;

namespace WpfApp1
{

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer timer = new DispatcherTimer();
        int duration_in_seconds = 1;

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        public MainWindow()
        {
            InitializeComponent();
            timer_dispatcher();
        }

        private void timer_dispatcher()
        {
            //Timer     

            timer.Tick += timer_tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        void timer_tick(object sender, EventArgs e)
        {
            SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED | EXECUTION_STATE.ES_CONTINUOUS | EXECUTION_STATE.ES_AWAYMODE_REQUIRED);

            

            duration_in_seconds += 1;
            TimeSpan timespan = TimeSpan.FromSeconds(duration_in_seconds);
            int hour = timespan.Hours;
            int min = timespan.Minutes;
            int sec = timespan.Seconds;


            txt_out.Text =
               "hours: " + hour.ToString()
               + "\minutes: " + min.ToString()
               + "\nseconds: " + sec.ToString();
        }
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
            ES_SYSTEM_REQUIRED = 0x00000001
            // Legacy flag, should not be used.
            // ES_USER_PRESENT = 0x00000004
        }

    }

    
  

    
}
