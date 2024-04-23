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
using System.Windows.Threading;

namespace MarathonWPF
{
    public partial class MainWindow : Window
    {
        public static readonly DateTime MaraphoneDateTime = new DateTime(2024,12,31,12,0,0);

        private DispatcherTimer timer;
        private TimeSpan timeBeforeMaraphone => MaraphoneDateTime - DateTime.Now;

        private readonly Uri _homePageUri = new Uri("Pages/HomePage.xaml", UriKind.Relative);

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += UpdateTimer;
            timer.Interval = TimeSpan.FromMinutes(1);
            timer.Start();
            UpdateTimer(null,null);
            MainFrame.Navigate(_homePageUri);
            MainFrame.NavigationService.Navigated += OnPageChanged;
        }

        private void UpdateTimer(object sender, EventArgs e)
        {
            TimeCountdownTB.Text = $"{timeBeforeMaraphone.Days} дней. {timeBeforeMaraphone.Hours} часов. {timeBeforeMaraphone.Minutes} минут.";
        }

        private void OnPageChanged(object sender, NavigationEventArgs e)
        {
            if(e.Uri == _homePageUri)
            {
                BackBtn.Visibility = Visibility.Hidden;
                CompetionDateTb.Visibility = Visibility.Visible;
                MainGrid.RowDefinitions.First().Height = new GridLength(100, GridUnitType.Star);
            }
            else
            {
                BackBtn.Visibility = Visibility.Visible;
                CompetionDateTb.Visibility = Visibility.Collapsed;
                MainGrid.RowDefinitions.First().Height = new GridLength(45, GridUnitType.Star);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }
    }
}