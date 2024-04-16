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

namespace MarathonWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void AdditionalInfoBtn_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).MainFrame.Navigate(new Uri("Pages/DetailedInfoPage.xaml", UriKind.Relative));
        }

        private void SponsorBtn_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).MainFrame.Navigate(new Uri("Pages/SponsorRegPage.xaml", UriKind.Relative));
        }

        private void RunnerBtn_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).MainFrame.Navigate(new Uri("Pages/RunnerEnterPage.xaml", UriKind.Relative));
        }
    }
}
