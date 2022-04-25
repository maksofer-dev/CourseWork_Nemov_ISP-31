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


namespace IS_EmployeesAccounting
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            OpenPage(pages.loginPage);
        }

        private void AuthorizationBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        public enum pages
        {
            loginPage
        }
        public void OpenPage(pages pages)
        {
            
            if (pages == pages.loginPage)
            {
                authorizationFrame.Navigate(new LoginPage (this));
            }
            


        }
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
