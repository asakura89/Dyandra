using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace Dyandra.View {
    public partial class DyandraWindow : UserControl {
        const Int32 TimerInterval = 50;
        const Double TimerIntervalDouble = 50d;

        Timer stopwatchTimer = new Timer(TimerInterval);
        TimeSpan elapsed = new TimeSpan();

        public DyandraWindow() {
            InitializeComponent();

            var timer = new Timer(TimerInterval);
            timer.Elapsed += TimerOnElapsed;
            timer.Start();

            stopwatchTimer.Elapsed += StopWatchTimerOnElapsed;
        }

        void TimerOnElapsed(Object sender, ElapsedEventArgs e) {
            String time = DateTime.Now.ToString("h:mm:ss tt zz");
            Dispatcher.Invoke(() => TxtTime.Text = time);
        }

        void StopWatchTimerOnElapsed(Object sender, ElapsedEventArgs e) {
            elapsed = TimeSpan.FromMilliseconds(elapsed.TotalMilliseconds + TimerIntervalDouble);
            Dispatcher.Invoke(UpdateStopwatchText);
        }

        void UpdateStopwatchText() =>
            TxtStopwatch.Text = $"{elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}.{elapsed.Milliseconds:000}";

        void StartButton_Click(Object sender, RoutedEventArgs e) {
            if (!stopwatchTimer.Enabled)
                stopwatchTimer.Start();
        }

        void StopButton_Click(Object sender, RoutedEventArgs e) {
            if (stopwatchTimer.Enabled)
                stopwatchTimer.Stop();
        }

        void ResetButton_Click(Object sender, RoutedEventArgs e) {
            stopwatchTimer.Stop();
            elapsed = new TimeSpan();
            UpdateStopwatchText();
        }
    }
}
