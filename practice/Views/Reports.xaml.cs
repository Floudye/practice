using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Xceed.Words.NET;
using Microsoft.Win32;


namespace practice.Views
{
    /// <summary>
    /// Логика взаимодействия для Reports.xaml
    /// </summary>
    public partial class Reports : Page
    {
        public Reports()
        {
            InitializeComponent();
        }

        private void btn_report_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word documents (*.docx)|*.docx";
            saveFileDialog.DefaultExt = "docx";
            saveFileDialog.AddExtension = true;
            saveFileDialog.FileName = "Отчет_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".docx";

            if (saveFileDialog.ShowDialog() == true)
            {
                var filePath = saveFileDialog.FileName;

                var doc = DocX.Create(filePath);
                doc.InsertParagraph("Отчет по аренде машин в автопарке").FontSize(16).Bold().Alignment = Alignment.center;
                doc.InsertParagraph($"Дата создания отчета: {DateTime.Now}").FontSize(12).Italic().Alignment = Alignment.center;


                var context = new practiceEntities();
                var rentals = context.Rentals.ToList();

                if (rentals.Any())
                {
                    var table = doc.AddTable(rentals.Count + 1, 5);

                    table.Rows[0].Cells[0].Paragraphs.First().Append("Модель");
                    table.Rows[0].Cells[1].Paragraphs.First().Append("Клиент");
                    table.Rows[0].Cells[2].Paragraphs.First().Append("Дата получения");
                    table.Rows[0].Cells[3].Paragraphs.First().Append("Дата возврата");
                    table.Rows[0].Cells[4].Paragraphs.First().Append("Статус");



                    for (int i = 0; i < rentals.Count; i++)
                    {
                        table.Rows[i + 1].Cells[0].Paragraphs.First().Append(rentals[i].Cars.Model);
                        table.Rows[i + 1].Cells[1].Paragraphs.First().Append(rentals[i].Clients.Username);
                        table.Rows[i + 1].Cells[2].Paragraphs.First().Append(rentals[i].StartDate.ToString());
                        table.Rows[i + 1].Cells[3].Paragraphs.First().Append(rentals[i].EndDate.ToString());
                        table.Rows[i + 1].Cells[4].Paragraphs.First().Append(rentals[i].CarStatus.StatusDescription);
                    }

                    doc.InsertTable(table);
                }
                else
                {
                    doc.InsertParagraph("Нет данных");
                }

                doc.InsertParagraph("\n");
                string signaturePath = "\\Resourses\\signature.png";
                Xceed.Words.NET.Image image = doc.AddImage(signaturePath);
                Picture signature = image.CreatePicture(30, 100);

                doc.InsertParagraph("Сдал Исполнитель: Автопарк").Bold().FontSize(12);
                doc.InsertParagraph(DateTime.Now.ToString()).FontSize(12);
                doc.InsertParagraph("М.П. ").FontSize(12).AppendPicture(signature);
                doc.Save();
                MessageBox.Show($"Отчет сохранен: {filePath}");
            }
        }
    }
}
