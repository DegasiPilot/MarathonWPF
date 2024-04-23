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
using System.Windows.Shapes;

namespace MarathonWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для CharityInfoWindow.xaml
    /// </summary>
    public partial class CharityInfoWindow : Window
    {
        public CharityInfoWindow(Charity charity)
        {
            InitializeComponent();
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri($"/Assets/Charity/{charity.CharityLogo}", UriKind.Relative);
            imageSource.EndInit();
            logoImage.Source = imageSource;
            this.DataContext = charity;
        }
    }
}
