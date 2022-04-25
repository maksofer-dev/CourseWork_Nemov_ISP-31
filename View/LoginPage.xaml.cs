using IS_EmployeesAccounting.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public AuthorizationWindow authorizationWindow;
        public LoginPage(AuthorizationWindow _authorizationWindow)
        {
            InitializeComponent();
            authorizationWindow = _authorizationWindow;

        }

        private void logClearButt_Click(object sender, RoutedEventArgs e)
        {
            logBox.Clear();

        }


        private void showPass_Click(object sender, RoutedEventArgs e)
        {
            passBox2.Text = passBox.Password;
            passBox.Visibility = Visibility.Hidden;
            passBox2.Visibility = Visibility.Visible;
            showPassIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.EyeOff;
            Button btn = sender as Button;
            btn.Click -= new RoutedEventHandler(showPass_Click);
            btn.Click += new RoutedEventHandler(showPass_Click_1);
        }
        private void showPass_Click_1(object sender, RoutedEventArgs e)
        {

            passBox.Password = passBox2.Text;
            passBox.Visibility = Visibility.Visible;
            passBox2.Visibility = Visibility.Hidden;
            showPassIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Eye;
            Button btn = sender as Button;
            btn.Click -= new RoutedEventHandler(showPass_Click_1);
            btn.Click += new RoutedEventHandler(showPass_Click);
        }

        private void LogButton_Click(object sender, RoutedEventArgs e)
        {
            if (logBox.Text.Length > 0)
            {
                if (passBox.Password.Length > 0)
                {
                    SqlCommands command = new SqlCommands();
                    DataTable dt_user = command.Select("SELECT * FROM [dbo].[Users] WHERE [login] = '" + logBox.Text + "' AND [password] = '" + passBox.Password + "'");
                    if (dt_user.Rows.Count > 0) // если такая запись существует       
                    {
                        MainMenuWindow mainMenuWindow = new MainMenuWindow();
                        mainMenuWindow.Show();
                        authorizationWindow.Close();
                    }
                    else
                    {
                        MessageBox.Show("Пользователя не найден");
                    }
                }
                else
                {
                    MessageBox.Show("Не введен пароль!");

                }
            }
            else
            {
                MessageBox.Show("Не введен логин!");
            }
        }

        private void helpButt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Для регистрации обратитесь к администратору", "Помощь",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
