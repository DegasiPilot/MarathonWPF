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
            RunnerCB.ItemsSource = (from reg in App.db.Registration select reg.Runner).ToList();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            (Application.Current.MainWindow as MainWindow).MainFrame.GoBack();
        }

        private void NumberTB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach(char letter in e.Text)
            {
                if (!char.IsDigit(letter))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        private void CharityAmountMinusBTn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CharitySelectorTB.Text, out int amount))
            {
                if (amount >= 10)
                {
                    CharitySelectorTB.Text = $"{amount - 10}";
                }
                else
                {
                    CharitySelectorTB.Text = $"{0}";
                }
            }
        }

        private void CherityAmountPlusBTn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(CharitySelectorTB.Text, out int amount))
            {
                CharitySelectorTB.Text = $"{amount + 10}";
            }
        }

        private void CharitySelectorTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(CharitySelectorTB.Text, out int amount))
            {
                CharitySelectorTB.Text = $"{int.Parse(CharitySelectorTB.Text)}";
            }
            CharityAmountTB.Text = CharitySelectorTB.Text;
        }

        private void payCharityBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(nameTB.Text))
            {
                errors.AppendLine("Заполните поле имя");
            }
            if (RunnerCB.SelectedIndex == -1)
            {
                errors.AppendLine("Выберите бегуна");
            }
            if (string.IsNullOrWhiteSpace(CartOwnerTB.Text))
            {
                errors.AppendLine("Заполните поле владелец карты");
            }
            if (string.IsNullOrWhiteSpace(CartNumberTB.Text))
            {
                errors.AppendLine("Заполните поле номер карты");
            }
            if (string.IsNullOrWhiteSpace(CartExpDateMonthTB.Text))
            {
                errors.AppendLine("Заполните поле месяц");
            }
            if (string.IsNullOrWhiteSpace(CartExpDateYearTB.Text))
            {
                errors.AppendLine("Заполните поле год");
            }
            if (string.IsNullOrWhiteSpace(CartCVVTB.Text))
            {
                errors.AppendLine("Заполните поле CVV");
            }

            if (int.TryParse(CharityAmountTB.Text, out int amount))
            {
                if(amount <= 0)
                {
                    errors.AppendLine("Сумма пожертвования должна быть больше 0");
                }
            }
            else
            {
                errors.AppendLine("Сумма пожертвования должна быть числом");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (CartNumberTB.Text.Length != 16)
            {
                errors.AppendLine("Номер кредитной карты должен быть 16 цифр");
            }
            if (CartCVVTB.Text.Length != 3)
            {
                errors.AppendLine("CVC является кодом безопасности, который должен содержать 3 цифры");
            }

            try
            {
                DateTime date = new DateTime(int.Parse(CartExpDateYearTB.Text), int.Parse(CartExpDateMonthTB.Text), 1);
                if (date < DateTime.Today)
                {
                    errors.AppendLine("Срок действия карты истек");
                }
            }
            catch
            {
                errors.AppendLine("Срок действия введен некорректно");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            else
            {
                Sponsorship sponsorship = new Sponsorship()
                {
                    SponsorName = nameTB.Text,
                    RegistrationId = (RunnerCB.SelectedItem as Runner).Registration.First().RegistrationId,
                    Amount = int.Parse(CharityAmountTB.Text),
                };
                App.db.Sponsorship.Add(sponsorship);
                App.db.SaveChanges();
                MessageBox.Show("Успешно");
                (Application.Current.MainWindow as MainWindow).MainFrame.GoBack();
            }
        }

        private void RunnerCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FoundNameTB.Text = (e.AddedItems[0] as Runner).Registration.First().Charity.CharityName;
        }

        private void CharityBtnInfo_Click(object sender, RoutedEventArgs e)
        {
            if(RunnerCB.SelectedIndex != -1)
            {
                CharityInfoWindow CharityInfoWindow = new CharityInfoWindow((RunnerCB.SelectedItem as Runner).Registration.First().Charity);

                CharityInfoWindow.ShowDialog();
            }
        }
    }
}
