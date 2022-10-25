using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace AsyncDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int sec = 0;
        private int min = 0;
        bool stop = false;

        #region Async
        private async Task CountOneAsync()
        {
            while (!stop)
            {
                OneAsync.Text = sec.ToString().Insert(sec.ToString().Length - 1, ".").Insert(0, "Sec:");
                sec++;
                await Task.Delay(100);
            }
        }

        private async Task CountTwoAsync()
        {
            while (!stop)
            {
                TwoAsync.Text = min.ToString().Insert(0, "Min:");
                min++;
                await Task.Delay(1000);
            }
        }

        private void AsyncButton_Click(object sender, RoutedEventArgs e)
        {
            CountOneAsync();
            CountTwoAsync();
        }

        #endregion

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            sec = 0;
            OneAsync.Text = sec.ToString();
            min = 0;
            TwoAsync.Text = min.ToString();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            stop = true;
        }
    }
}