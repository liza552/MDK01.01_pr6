using System;
using System.Windows;
using System.Windows.Controls;
using MDK01._01_PR3.Models;
using MDK01._01_PR3.Services;

namespace MDK01._01_PR3.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        private bool captchaShown;   // показана ли капча
        private string captchaText;  // правильный текст капчи

        public Autho()
        {
            InitializeComponent();
        }

        private void btnEnterGuests_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client(null, null));
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = pbPassword.Password.Trim();

            if (login == "" || password == "")
            {
                MessageBox.Show("Введите логин и пароль!");
                return;
            }

            User user = UserRepository.Find(login, password);

            // Если капча уже показана — она тоже должна быть введена верно
            bool captchaOk = !captchaShown || txtBoxCaptcha.Text == captchaText;

            if (user != null && captchaOk)
            {
                MessageBox.Show("Вы вошли под: " + user.Role);
                LoadPage(user.Role, user);
                return;
            }

            if (user != null)
                MessageBox.Show("Капча введена неверно!");
            else
                MessageBox.Show("Вы ввели логин или пароль неверно!");

            pbPassword.Clear();   // очистка поля пароля
            GenerateCaptcha();    // вывод (новой) капчи
        }

        private void GenerateCaptcha()
        {
            captchaShown = true;
            captchaText = CaptchaGenerator.GenerateCaptchaText(6);

            txtBlockCaptcha.Visibility = Visibility.Visible;
            txtBlockCaptchaText.Visibility = Visibility.Visible;
            txtBoxCaptcha.Visibility = Visibility.Visible;

            txtBlockCaptchaText.Text = captchaText;
            txtBoxCaptcha.Clear();
        }

        private void LoadPage(string role, User user)
        {
            captchaShown = false;
            txtBlockCaptcha.Visibility = Visibility.Collapsed;
            txtBlockCaptchaText.Visibility = Visibility.Collapsed;
            txtBoxCaptcha.Visibility = Visibility.Collapsed;
            pbPassword.Clear();

            switch (role)
            {
                case "Клиент":
                    NavigationService.Navigate(new Client(user, role));
                    break;
                default:
                    NavigationService.Navigate(new Client(user, role));
                    break;
            }
        }
    }
}