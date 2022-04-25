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
    /// Interaction logic for AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        private Employee _employee = new Employee();
        public AddEmployee(Employee selectedEmployee)
        {
            InitializeComponent();
            if (selectedEmployee != null)
                _employee = selectedEmployee;
            else
            {
                _employee.DateOfEmployement = DateTime.Now; 
                _employee.Birthday = DateTime.Now;  
            }

            DataContext = _employee;
            comboPositions.ItemsSource = AccountingEmployeesEntities1.GetContext().Positions.ToList();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_employee.FullName))
                errors.AppendLine("Укажите ФИО");
            if (_employee.TIN == null || _employee.TIN.Length < 12)
                errors.AppendLine("ИНН должен содержать 12 цифр");
            if (string.IsNullOrWhiteSpace(_employee.Division))
                errors.AppendLine("Укажите отдел");
            if (_employee.TabNum == 0)
                errors.AppendLine("Укажите табельный номер");
            if (_employee.Position == null)
                errors.AppendLine("Выберете должность");
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if(_employee.id == 0)
            {
                AccountingEmployeesEntities1.GetContext().Employees.Add(_employee);
            }
            try
            {
                AccountingEmployeesEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                addEmployeeWindow.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }



        private void TextBlock_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addEmployeeBorder_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            addEmployeeWindow.Close();
        }
    }
}
