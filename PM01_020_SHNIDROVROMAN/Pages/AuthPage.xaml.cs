using PM01_020_SHNIDROVROMAN.DataBase;
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

namespace PM01_020_SHNIDROVROMAN.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private void txt_login_Changed(object sender, RoutedEventArgs e)
        {
            txtHintLogin.Visibility = Visibility.Visible;
            if (txt_login.Text.Length > 0)
                txtHintLogin.Visibility = Visibility.Hidden;
        }

        private void PasswordBox_Changed(object sender, RoutedEventArgs e)
        {
            txtHintPswd.Visibility = Visibility.Visible;
            if (PasswordBox.Password.Length > 0)
                txtHintPswd.Visibility = Visibility.Hidden;
        }
        public AuthPage(object p)
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_login.Text) || string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Пожалуйста, введите пароль и почту");
                return;
            }
            using (var db = new Entities())
            {
                var user = db.Moderators
                    .AsNoTracking()
                    .FirstOrDefault(u => u.Mail == txt_login.Text && u.Password == PasswordBox.Password);
                if (user == null)
                {
                    MessageBox.Show("Пользователь с такими данными не найден!");
                    return;
                }
                else
                    MessageBox.Show("Добро пожаловать! Вы успешно авторизовались");
                switch (user.Event)
                {
                    case "Пользователь":
                        NavigationService?.Navigate(new CustomerMenu());
                        break;
                    case "":
                        NavigationService?.Navigate(new DirectorMenu());
                        break;
                }
            }
        }


        private void txt_login_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtHintLogin.Visibility = Visibility.Visible;
            if (txt_login.Text.Length > 0)
                txtHintLogin.Visibility = Visibility.Hidden;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtHintPswd.Visibility = Visibility.Visible;
            if (PasswordBox.Password.Length > 0)
                txtHintPswd.Visibility = Visibility.Hidden;
        }
    }
}
