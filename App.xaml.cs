using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MarathonWPF
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static MarathonEntities db = new MarathonEntities();
        public static Frame MainFrame => (Current.MainWindow as MainWindow).MainFrame;
    }
}
