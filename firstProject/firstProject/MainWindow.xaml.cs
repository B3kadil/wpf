using System;
using System.IO;
using System.Windows;
using Newtonsoft.Json;
using System.Windows.Controls;

namespace firstProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeCities();
         }

        private void InitializeCities()
        {
            City.Items.Add("Алматы");
            City.Items.Add("Тараз");
            City.Items.Add("Караганда");                              
        }

        private void CitySelChange(object sender, SelectionChangedEventArgs e)
        {
            string selectedCity = City.SelectedItem.ToString();
            UpdateWorkshops(selectedCity);
        }

        private void WorkSelChange(object sender, SelectionChangedEventArgs e)
        {
            string selectedWorkshop = Work.SelectedItem.ToString();
            UpdateEmpl(selectedWorkshop);
        }

        private void UpdateWorkshops(string selectedCity)
        {
            Work.Items.Clear();

            switch (selectedCity)
            {
                case "Алматы":
                    Work.Items.Add("Цех 1");
                    Work.Items.Add("Цех 2");
                    break;
                case "Тараз":
                    Work.Items.Add("Цех 3");
                    Work.Items.Add("Цех 4");
                    break;
                case "Караганда":
                    Work.Items.Add("Цех 5");
                    Work.Items.Add("Цех 6");
                    break;
            }
        }

        private void UpdateEmpl(string selectedWorkshop)
        {
            Empl.Items.Clear();

            switch (selectedWorkshop)
            {
                case "Цех 1":
                    Empl.Items.Add("Сотрудник 1");
                    Empl.Items.Add("Сотрудник 2");
                    break;
                case "Цех 2":
                    Empl.Items.Add("Сотрудник 3");
                    Empl.Items.Add("Сотрудник 4");
                    break;
                case "Цех 3":
                    Empl.Items.Add("Сотрудник 5");
                    Empl.Items.Add("Сотрудник 6");
                    break;
                case "Цех 4":
                    Empl.Items.Add("Сотрудник 7");
                    Empl.Items.Add("Сотрудник 8");
                    break;
                case "Цех 5":
                    Empl.Items.Add("Сотрудник 9");
                    Empl.Items.Add("Сотрудник 10");
                    break;
                case "Цех 6":
                    Empl.Items.Add("Сотрудник 11");
                    Empl.Items.Add("Сотрудник 12");
                    break;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var dataToSave = new
            {
                City = City.SelectedItem?.ToString(),
                Workshop = Work.SelectedItem?.ToString(),
                Employee = Empl.SelectedItem?.ToString(),
                Brigade = Brigade.SelectedItem?.ToString(),
                Shift = Shift.SelectedItem?.ToString()
            };
            {
                string jsonData = JsonConvert.SerializeObject(dataToSave, Formatting.Indented);

                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data.json");
                File.WriteAllText(filePath, jsonData);
                MessageBox.Show($"Данные сохранены в файл {filePath}");
            }          
        }
    }
}
