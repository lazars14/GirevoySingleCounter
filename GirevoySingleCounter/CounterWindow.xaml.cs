using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
            main_window = mainWindow;

            counter = 0;
            counter_txtb.Text = counter.ToString();

            time = minutes * 60; // time in seconds

            setDispatchTimer(minutes);
            this.KeyDown += HandleKeyPress;
        }

        private void setDispatchTimer(int minutes)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Timer_Tick;

            setTime();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if(time > 0)
            {
                time--;
                setTime();
            }
            else
            {
                timer.Stop();
            }
        }

        private void setTime()
        {
            if ((time / 60) < 10)
            {
                timer_txtb.Text = string.Format("0{0}:{1}", time / 60, time % 60);
            }
            if(time % 60 == 0)
            {
                timer_txtb.Text = string.Format("0{0}:{1}0", time / 60, time % 60);
            }
            else
            {
                timer_txtb.Text = string.Format("{0}:{1}", time / 60, time % 60);
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
                    counter_txtb.Text = counter.ToString();
                    break;
                case Key.Subtract:
                    --counter;
                    counter_txtb.Text = counter.ToString();
                    break;
                case Key.Escape:
                    main_window.Show();
                    this.Close();
                    break;
            }
        }
    }
}
