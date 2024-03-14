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
    /// Логика взаимодействия для CarsTable.xaml
    /// </summary>
    public partial class CarsTable : Page
    {
        List<Car> CarsList;
        public CarsTable()
        {
            InitializeComponent();
            var context = new practiceEntities();

            CarsList = context.Cars.Select(r => new Car
            {
                Brand = r.Brand,
                Model = r.Model,
                Year = r.Year,
                Color = r.CarColors.ColorName,
                VIN = r.VIN,
                Status = r.CarStatus.StatusDescription
            }).ToList();

            DataGridCars.ItemsSource = CarsList;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = FilterTextBox.Text.ToLower();
            var filteredList = CarsList.Where(c =>
                c.Brand.ToLower().Contains(filter) ||
                c.Model.ToLower().Contains(filter) ||
                c.Year.ToString().Contains(filter) ||
                c.Color.ToLower().Contains(filter)).ToList();

            DataGridCars.ItemsSource = filteredList;
        }
    }
}
