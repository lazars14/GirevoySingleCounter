using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace GirevoySingleCounter
{
    /// <summary>
    /// Interaction logic for CounterWindow.xaml
    /// </summary>
    public partial class CounterWindow : Window
    {
        private MainWindow main_window { get; set; }
        private DispatcherTimer timer { get; set; }

        private int counter { get; set; }
        private int time { get; set; }

        public CounterWindow(MainWindow mainWindow, int minutes)
        {
            InitializeComponent();
            this.DataContext = counter;
            counter = 0;
            time = minutes * 60; // time in seconds

            main_window = mainWindow;
            setDispatchTimer(minutes);
            this.KeyDown += HandleKeyPress;
        }

        private void setDispatchTimer(int minutes)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(time > 0)
            {
                time--;
                if ((time / 60) < 10)
                {
                    timer_txtb.Text = string.Format("0{0}:{1}", time / 60, time % 60);
                }
                else
                {
                    timer_txtb.Text = string.Format("{0}:{1}", time / 60, time % 60);
                }
            }
            else
            {
                timer.Stop();
            }
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Return:
                    timer.Start();
                    break;
                case Key.Space:
                    ++counter;
                    break;
                case Key.Subtract:
                    --counter;
                    break;
                case Key.Escape:
                    main_window.Show();
                    this.Close();
                    break;
            }
        }
    }
}
