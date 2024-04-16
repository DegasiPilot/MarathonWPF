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
    /// Логика взаимодействия для SponsorRegPage.xaml
    /// </summary>
    public partial class SponsorRegPage : Page
    {
        public SponsorRegPage()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).MainFrame.GoBack();
        }
    }
}
