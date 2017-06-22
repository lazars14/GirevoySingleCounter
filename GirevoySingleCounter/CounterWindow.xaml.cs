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

        public CounterWindow(MainWindow mainWindow, int minutes)
        {
            InitializeComponent();
            counter = 0;

            main_window = mainWindow;
            setDispatchTimer(minutes);
            this.KeyDown += HandleKeyPress;
        }

        private void setDispatchTimer(int minutes)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, minutes, 0);
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
