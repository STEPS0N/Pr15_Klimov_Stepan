using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TimeLord_Klimov.Pages
{
    /// <summary>
    /// Логика взаимодействия для Timer.xaml
    /// </summary>
    public partial class Timer : Page
    {
        private SoundPlayer soundPlayer;
        DispatcherTimer timer = new DispatcherTimer();
        DispatcherTimer soundtimer = new DispatcherTimer();
        public float full_seconds;
        public bool start_timer = false;

        public Timer()
        {
            InitializeComponent();

            timer.Tick += TimerSecond;
            timer.Interval = new TimeSpan(0, 0, 1);
        }

        private void TimerSecond(object sender, EventArgs e)
        {
            if (full_seconds > 0)
            {
                full_seconds--;

                float hours = (int)(full_seconds / 60 / 60);
                float minutes = (int)(full_seconds / 60) - (hours * 60);
                float seconds = full_seconds - (hours * 60 * 60) - (minutes * 60);

                string s_seconds = seconds.ToString();
                if (seconds < 10)
                {
                    s_seconds = "0" + seconds;
                }

                string s_minutes = minutes.ToString();
                if (minutes < 10)
                {
                    s_minutes = "0" + minutes;
                }

                string s_hours = hours.ToString();
                if (hours < 10)
                {
                    s_hours = "0" + hours;
                }

                time.Content = s_hours + ":" + s_minutes + ":" + s_seconds;
            }
            else
            {
                timer.Stop();
                start_timer = false;
                start.Content = "Начать";
                PlayMySound(5);
                MessageBox.Show("Время вышло!");
            }
        }

        private void StartTimer(object sender, RoutedEventArgs e)
        {
            if (start_timer == false)
            {
                if (full_seconds == 0)
                {
                    if (reg_text.Text != null && RegexCheck(reg_text.Text, @"^\d{2}:\d{2}:\d{2}$"))
                    {
                        string text = reg_text.Text;
                        string[] stroke = text.Split(':');
                        float hours = float.Parse(stroke[0]);
                        float minuts = float.Parse(stroke[1]);
                        float seconds = float.Parse(stroke[2]);

                        if (minuts < 60 && seconds < 60)
                        {
                            full_seconds = hours * 3600 + minuts * 60 + seconds;

                            time.Content = $"{hours}:{minuts}:{seconds}";

                            start_timer = true;
                            timer.Start();
                            start.Content = "Стоп";
                        }
                        else
                        {
                            MessageBox.Show("Минуты и секунды могут быть в формате до 60");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильный формат введённых данных!");
                    }
                }
                else
                {
                    full_seconds = full_seconds;
                    timer.Start();
                    start_timer = true;
                    start.Content = "Стоп";
                }
            }
            else
            {
                full_seconds = full_seconds;
                timer.Stop();
                start_timer = false;
                start.Content = "Продолжить";
            }
        }

        private static bool RegexCheck(string input, string pattern)
        {
            Match m = Regex.Match(input, pattern);
            return m.Success;
        }

        private void GoToStopwatch(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            start_timer = false;
            NavigationService.Navigate(new Stopwatch());
        }

        private void ResetTimer(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            start_timer = false;
            full_seconds = 0;
            time.Content = "00:00:00";
            start.Content = "Начать";
        }
        private void PlayMySound(int durationSeconds)
        {
            soundPlayer = new SoundPlayer("D:/3 курс/Ощепков/Практические работы/Практическая работа №15/TimeLord_Klimov/TimeLord_Klimov/Sound/tu-tu-tu-du-max-verstappen.wav");
            soundPlayer.Play();

            soundtimer.Interval = TimeSpan.FromSeconds(durationSeconds);
            soundtimer.Start();
        }
    }
}
