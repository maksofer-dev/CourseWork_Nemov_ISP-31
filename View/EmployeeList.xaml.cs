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

namespace IS_EmployeesAccounting
{
    /// <summary>
    /// Interaction logic for EmployeeList.xaml
    /// </summary>
    public partial class EmployeeList : Window
    {
        
        public EmployeeList()
        {
            InitializeComponent();
            dGridEmployeess.ItemsSource = AccountingEmployeesEntities1.GetContext().Employees.ToList();

        }

        private void employeeBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenuWindow = new MainMenuWindow();   
            mainMenuWindow.Show();
            employeeList.Hide();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee(null);
            addEmployee.Show();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var employeeForRemoving = dGridEmployeess.SelectedItems.Cast<Employee>().ToList();
            if(MessageBox.Show($"Вы точно хотите удалить следующие {employeeForRemoving.Count()} элементов?", "Внимание", 
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AccountingEmployeesEntities1.GetContext().Employees.RemoveRange(employeeForRemoving);
                    AccountingEmployeesEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    dGridEmployeess.ItemsSource = AccountingEmployeesEntities1.GetContext().Employees.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee((sender as Button).DataContext as Employee);
            addEmployee.Show();

        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            AccountingEmployeesEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dGridEmployeess.ItemsSource = AccountingEmployeesEntities1.GetContext().Employees.ToList();
        }
    }
}
