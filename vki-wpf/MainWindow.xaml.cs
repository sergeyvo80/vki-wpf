using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using vki_wpf.Models;

namespace vki_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private OvchinnikovLmsContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = new OvchinnikovLmsContext();
            LoadGroups();
            LoadStudents();
        }


        // Загрузка студентов из базы данных
        private void LoadStudents()
        {
            try
            {
                // Загружаем студентов вместе с информацией о группах
                var students = _context.Students
                    .Include(s => s.Group)  // Важно: включаем связанные данные о группе
                    .OrderBy(s => s.LastName)
                    .ThenBy(s => s.FirstName)
                    .ToList();

                studentsDataGrid.ItemsSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }



        private void LoadGroups()
        {
            var groups = _context.Groups.OrderBy(g => g.GroupName).ToList();
            cmbGroups.ItemsSource = groups;
            cmbGroups.DisplayMemberPath = "GroupName";
            cmbGroups.SelectedValuePath = "GroupId";
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void CmbGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            var students = _context.Students.Include(s => s.Group).AsQueryable();

            // Фильтр по поиску
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                students = students.Where(s =>
                    s.FirstName.Contains(txtSearch.Text) ||
                    s.LastName.Contains(txtSearch.Text));
            }

            // Фильтр по группе
            if (cmbGroups.SelectedValue != null)
            {
                int selectedGroupId = (int)cmbGroups.SelectedValue;
                students = students.Where(s => s.GroupId == selectedGroupId);
            }

            studentsDataGrid.ItemsSource = students
                .OrderBy(s => s.LastName)
                .ThenBy(s => s.FirstName)
                .ToList();
        }

        private void BtnResetFilters_Click(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = string.Empty;
            cmbGroups.SelectedIndex = -1;
            LoadStudents();
        }

    }
}