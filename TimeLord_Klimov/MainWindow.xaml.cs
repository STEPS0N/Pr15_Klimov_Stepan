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

            OpenPages(pages.stopwatch, pages.timer);
        }

        public enum pages
        {
            stopwatch,
            timer
        }

        public void OpenPages(pages _page, pages _timer)
        {
            if (_page == pages.stopwatch)
            {
                frame.Navigate(new Pages.Stopwatch());
            }

            else if (_timer == pages.timer)
            {
                frame.Navigate(new Pages.Timer());
            }
        }
    }
}