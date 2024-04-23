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
using MarathonWPF.Components;

namespace MarathonWPF.Pages
{
    /// <summary>
    /// Логика взаимодействия для CharityListPage.xaml
    /// </summary>
    public partial class CharityListPage : Page
    {
        public CharityListPage()
        {
            InitializeComponent();
            foreach (var item in App.db.Charity.ToList())
            {
                charityListWP.Children.Add(new CharityListUserControl(item));
            }
        }
    }
}
