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

namespace practice.Views
{
    /// <summary>
    /// Логика взаимодействия для RegisterView.xaml
    /// </summary>
    public partial class SignUpView : Window
    {
        private string Password;
        public SignUpView()
        {
            InitializeComponent();
        }

        private void btn_signUp_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) || string.IsNullOrWhiteSpace(PasswordTextBox.Password) ||
            string.IsNullOrWhiteSpace(FirstNameTextBox.Text) || string.IsNullOrWhiteSpace(SecondNameTextBox.Text) ||
            string.IsNullOrWhiteSpace(PatronymicTextBox.Text) || string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return; 
            }

            using (var context = new practiceEntities())
            {
                var user = new Clients
                {
                    Username = UsernameTextBox.Text,
                    Password = Password,
                    FirstName = FirstNameTextBox.Text,
                    SecondName = SecondNameTextBox.Text,
                    Patronymic = PatronymicTextBox.Text,
                    PhoneNumber = PhoneNumberTextBox.Text,
                };
                context.Clients.Add(user);
                context.SaveChanges();
            }

            MessageBox.Show("Пользователь зарегистрирован.");
            this.Close();
        }
        private void PasswordBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = (PasswordBox)sender;
            Password = passwordBox.Password;
        }
    }
}
