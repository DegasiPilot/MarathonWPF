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
    /// Логика взаимодействия для RegistrationToMaraphonPage.xaml
    /// </summary>
    public partial class RegistrationToMaraphonPage : Page
    {
        int TotalAmount;
        int kitPrice;
        int amount;
        int type1Amount;
        int type2Amount;
        int type3Amount;
        Charity selectedCharity;

        public RegistrationToMaraphonPage()
        {
            InitializeComponent();
        }

        private void UpdateTotalAmount()
        {
            TotalAmount = kitPrice + amount + type1Amount + type2Amount + type3Amount;
            SponsorshipAmountBT.Text = TotalAmount.ToString();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            NavigationService.RemoveBackEntry();
        }

        private void RegBTn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FullMarathonCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (FullMarathonCheckBox.IsChecked == true)
            {
                type3Amount = 145;
            }
            else
            {
                type3Amount = 0;
            }
            UpdateTotalAmount();
        }

        private void HalfMarathonCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (HalfMarathonCheckBox.IsChecked == true)
            {
                type2Amount = 75;
            }
            else
            {
                type2Amount = 0;
            }
            UpdateTotalAmount();
        }

        private void ShortRangeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (HalfMarathonCheckBox.IsChecked == true)
            {
                type1Amount = 20;
            }
            else
            {
                type1Amount = 0;
            }
            UpdateTotalAmount();
        }

        private void SponsorsCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCharity = SponsorsCB.SelectedItem as Charity;

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            kitPrice = 0;
            UpdateTotalAmount();
        }


        private void kitRB20Bucks_Checked(object sender, RoutedEventArgs e)
        {
            kitPrice = 20;
            UpdateTotalAmount();
        }

        private void kitRB45Bucks_Checked(object sender, RoutedEventArgs e)
        {
            kitPrice = 45;
            UpdateTotalAmount();
        }
    }
}
