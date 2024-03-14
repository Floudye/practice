using Microsoft.Win32;
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
    /// Логика взаимодействия для LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private string Password;

        public LoginView()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new practiceEntities())
            {
                var user = context.Clients
                    .FirstOrDefault(u => u.Username == UsernameTextBox.Text
                    && u.Password == Password);

                if (user != null)
                {
                    MainView main = new MainView();
                    main.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неправильный логин или пароль.");
                }
            }
        }


        private void SignUp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SignUpView signUp = new SignUpView();
            signUp.Show();
        }

        private void PasswordBox1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = (PasswordBox)sender;
            Password = passwordBox.Password;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
