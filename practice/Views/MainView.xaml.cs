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
    /// Логика взаимодействия для MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
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

        private void btn_cars_Click(object sender, RoutedEventArgs e)
        {
            MainFrane.Content = new CarsTable();
        }
        private void btn_clients_Click(object sender, RoutedEventArgs e)
        {
            MainFrane.Content = new ClientsTable();
        }
        private void btn_rentals_Click(object sender, RoutedEventArgs e)
        {
            MainFrane.Content = new RentalsTable();

        }
        private void btn_reports_Click(object sender, RoutedEventArgs e)
        {
            MainFrane.Content = new Reports();

        }
    }
}
