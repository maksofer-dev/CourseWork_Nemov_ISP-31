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
    /// Логика взаимодействия для MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        EmployeeList employeeList = new EmployeeList();
        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void mainMenuBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void employeeBtn_Click(object sender, RoutedEventArgs e)
        {
            employeeList.Show();
            this.mainMenuWindow.Close();
        }

        private void ordersBtn_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow ordersWindow = new OrdersWindow();
            ordersWindow.Show();
            this.mainMenuWindow.Close();

        }
    }
}
