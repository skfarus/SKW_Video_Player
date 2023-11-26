using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace SKW_Video_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext=new MainWindowViewModel();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            MediaElement1.Play();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            MediaElement1.Pause();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            MediaElement1.Stop();
        }

        private void ForwardOneFrameButton_Click(object sender, RoutedEventArgs e)
        {
            MediaElement1.Position = TimeSpan.FromMilliseconds(MediaElement1.Position.TotalMilliseconds + 33);

            MediaElement1.Play();
            MediaElement1.Pause();
        }

        private void BackwardsOneFrameButton_Click(object sender, RoutedEventArgs e)
        {
            MediaElement1.Position = TimeSpan.FromMilliseconds(MediaElement1.Position.TotalMilliseconds - 33);

            MediaElement1.Play();
            MediaElement1.Pause();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double SliderValue = timelineSlider.Value;

            MediaElement1.Position = TimeSpan.FromMilliseconds(MediaElement1.NaturalDuration.TimeSpan.TotalMilliseconds * SliderValue);
        }

        private TimeSpan TotalTime;
        private DispatcherTimer timerVideoTime;

        private void MediaElement1_MediaOpened(object sender, RoutedEventArgs e)
        {
            TotalTime = MediaElement1.NaturalDuration.TimeSpan;

            // Create a timer that will update the counters and the time slider
            timerVideoTime = new DispatcherTimer();
            timerVideoTime.Interval = TimeSpan.FromSeconds(1);
            timerVideoTime.Tick += new EventHandler(timer_Tick);
            timerVideoTime.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            // Check if the movie finished calculate it's total time
            if (MediaElement1.NaturalDuration.TimeSpan.TotalSeconds > 0)
            {
                if (TotalTime.TotalSeconds > 0)
                {
                    // Updating time slider
                    timelineSlider.Value = MediaElement1.Position.TotalSeconds / TotalTime.TotalSeconds;
                }
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {/*
            Slider slider= timelineSlider;
            timelineSlider = new Slider();
            timelineSlider.Value = slider.Value;
            timelineSlider.Name = slider.Name;
            timelineSlider.Orientation = Orientation.Horizontal;
            timelineSlider.Maximum = 1;
            timelineSlider.ValueChanged += Slider_ValueChanged;*/
        }
    }
}
