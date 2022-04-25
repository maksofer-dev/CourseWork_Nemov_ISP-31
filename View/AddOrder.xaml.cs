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
    /// Interaction logic for AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        private Order _order = new Order();

        public AddOrder(Order selectedOrder)
        {
            InitializeComponent();
            if (selectedOrder != null)
                _order = selectedOrder;
            else
            {
                _order.date = DateTime.Now; 

            }
            
            DataContext = _order;

            comboOrderType.ItemsSource = AccountingEmployeesEntities1.GetContext().orderTypes.ToList();
        }

        private void addOrderBorder_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_order.Name))
                errors.AppendLine("Укажите ФИО");
            
            if (string.IsNullOrWhiteSpace(_order.Comment))
                errors.AppendLine("Укажите комментарий");
           
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_order.id == 0)
            {
                AccountingEmployeesEntities1.GetContext().Orders.Add(_order);
            }
            try
            {
                AccountingEmployeesEntities1.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                addOrderWindow.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            addOrderWindow.Close();

        }
    }
}
