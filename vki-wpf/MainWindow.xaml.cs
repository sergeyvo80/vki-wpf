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
    private OvchinnikovLmsContext _context;
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _context = new OvchinnikovLmsContext();
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
    }
}