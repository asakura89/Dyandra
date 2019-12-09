using System;
using System.Timers;
using System.Windows.Controls;

namespace Dyandra.View {
    public partial class DyandraWindow : UserControl {
        public DyandraWindow() {
            InitializeComponent();

            var timer = new Timer(500);
            timer.Elapsed += TimerOnElapsed;
            timer.Enabled = true;
        }

        void TimerOnElapsed(Object sender, ElapsedEventArgs e) {
            String time = DateTime.Now.ToString("h:mm:ss tt zz");
            Dispatcher.Invoke(() => TxtTime.Text = time);
        }
    }
}
