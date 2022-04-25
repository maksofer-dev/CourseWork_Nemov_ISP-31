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
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        public OrdersWindow()
        {
            InitializeComponent();
            dGridOrders.ItemsSource = AccountingEmployeesEntities1.GetContext().Orders.ToList();

        }

        private void ordersBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            AddOrder addOrder = new AddOrder((sender as Button).DataContext as Order);
            addOrder.Show();
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            AccountingEmployeesEntities1.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
            dGridOrders.ItemsSource = AccountingEmployeesEntities1.GetContext().Orders.ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddOrder addOrder = new AddOrder(null);
            addOrder.Show();
        }

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var orderForRemoving = dGridOrders.SelectedItems.Cast<Order>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {orderForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AccountingEmployeesEntities1.GetContext().Orders.RemoveRange(orderForRemoving);
                    AccountingEmployeesEntities1.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    dGridOrders.ItemsSource = AccountingEmployeesEntities1.GetContext().Orders.ToList();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();
            ordersWindow.Close();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
