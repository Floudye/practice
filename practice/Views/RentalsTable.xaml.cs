using practice.Models;
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

namespace practice.Views
{
    /// <summary>
    /// Логика взаимодействия для RentalsTable.xaml
    /// </summary>
    public partial class RentalsTable : Page
    {
        List<Rental> RentalsList;

        public RentalsTable()
        {
            InitializeComponent();
            var context = new practiceEntities();

            RentalsList = context.Rentals.Select(r => new Rental
            {
                Car = r.Cars.Model,
                Client = r.Clients.Username,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                Status = r.CarStatus.StatusDescription
            }).ToList();

            DataGridRentals.ItemsSource = RentalsList;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = FilterTextBox.Text.ToLower();
            var filteredList = RentalsList.Where(r =>
                r.Car.ToLower().Contains(filter) ||
                r.Client.ToLower().Contains(filter) ||
                r.StartDate.ToString().ToLower().Contains(filter) ||
                r.EndDate.ToString().ToLower().Contains(filter)).ToList();

            DataGridRentals.ItemsSource = filteredList;
        }
    }
}
