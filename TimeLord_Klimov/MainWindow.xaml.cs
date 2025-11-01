using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TimeLord_Klimov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OpenPageStopwatch(pages.stopwatch);
        }

        public enum pages
        {
            stopwatch,
            timer
        }

        public void OpenPageStopwatch(pages _page)
        {
            if (_page == pages.stopwatch)
            {
                frame.Navigate(new Pages.Stopwatch());
            }
        }

        public void OpenPageTimer(pages _page)
        {
            if (_page == pages.timer)
            {
                frame.Navigate(new Pages.Timer());
            }
        }

        private void StopwatchMenu_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Pages.Stopwatch());
        }

        private void TimerMenu_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new Pages.Timer());
        }
    }
}