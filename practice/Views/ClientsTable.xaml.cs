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
    /// Логика взаимодействия для ClientsTable.xaml
    /// </summary>
    public partial class ClientsTable : Page
    {
        List<Client> ClientsList;
        public ClientsTable()
        {
            InitializeComponent();
            var context = new practiceEntities();

            ClientsList = context.Clients.Select(r => new Client
            {
                FirstName = r.FirstName,
                SecondName = r.SecondName,
                Patronymic = r.Patronymic,
                PhoneNumber = r.PhoneNumber,
                Username = r.Username,
            }).ToList();

            DataGridClients.ItemsSource = ClientsList;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = FilterTextBox.Text.ToLower();
            var filteredList = ClientsList.Where(c =>
                c.FirstName.ToLower().Contains(filter) ||
                c.SecondName.ToLower().Contains(filter) ||
                c.Patronymic.ToLower().Contains(filter) ||
                c.PhoneNumber.ToLower().Contains(filter) ||
                c.Username.ToLower().Contains(filter)).ToList();

            DataGridClients.ItemsSource = filteredList;
        }
    }
}