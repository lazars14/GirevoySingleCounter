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

namespace GirevoySingleCounter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int minutes { get; set; }
        private static int DEFAULT_MINUTES_VALUE = 30;

        public MainWindow()
        {
            InitializeComponent();
            minutes = 0;
        }

        private void new_interval_btn_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            string minutes_text = new_interval_txtb.Text;
            if (!int.TryParse(minutes_text, out i))
            {
                minutes = DEFAULT_MINUTES_VALUE;
            }
            else
            {
                minutes = i;
            }


        }
    }
}
